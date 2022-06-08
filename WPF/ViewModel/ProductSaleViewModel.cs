using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
using Domain.Logic.Base;
using Domain.Services;
using Domain.Utilities;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using WPF.Command;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class ProductSaleViewModel : FormViewModel
    {
        public ICommand backCommand { get; }
        private ICommand buyStockCommand { get; }
        public ICommand salesChargeModalCommand { get; }

        public StockViewerViewModel stockViewer { get; }

        private readonly IMessenger messenger;

        private readonly SaleLogic logic;

        public ProductSaleViewModel(
            ILogic _logic,
            IMessenger _messenger,
            IAccountStore _accountStore,
            IBuyStockService buyStockService,
            ViewModelBase _stockViewer,
            INavigationService backNavigation,
            INavigationService modalNavigationService)
        {
            backCommand = new NavigateCommand(backNavigation);
            salesChargeModalCommand = new NavigateCommand(modalNavigationService);
            buyStockCommand = new BuyStockCommand(this, buyStockService);
            employee = _accountStore.currentAccount.EmployeeNavigation;

            stockViewer = (StockViewerViewModel)_stockViewer;

            logic = (SaleLogic)_logic;

            messenger = _messenger;
            messenger.Subscribe<StockViewerMessage>(this, AddDetail);

            detailListing = new();
            detailListing.CollectionChanged += DetailListing_Changed;
        }

        public ICommand finishSaleCommand => new RelayCommand(o =>
        {
            messenger.Send(new SaleChargeModalMessage(total, buyStockCommand));
            salesChargeModalCommand.Execute(null);
        });

        public void Reset()
        {
            messenger.Send(Refresh.sale);
            messenger.Send(Refresh.stock);
            ResetProperties();
        }

        private void ResetProperties()
        {
            selectedDiscount = null;
            detailListing.Clear();

            OnPropertyChanged(nameof(total));
            OnPropertyChanged(nameof(date));
        }

        public Employee employee { get; }

        public DateTime date => DateTime.Now;

        private double _total;
        public double total
        {
            get
            {
                _total = 0;

                foreach (var item in detailListing)
                    _total += item.Total;

                return discountApplies ? (1 - discount) * _total : _total;
            }
        }


        public ObservableCollection<SaleDetailView> detailListing { get; }

        private bool _stockViewerIsVisible;
        public bool stockViewerIsVisible
        {
            get => _stockViewerIsVisible;
            set
            {
                _stockViewerIsVisible = value;
                OnPropertyChanged(nameof(stockViewerIsVisible));
            }
        }

        private void AddDetail(object _parameter)
        {
            var parameter = ((StockViewerMessage)_parameter).element;

            SaleDetailView result = GetIndexDetail(parameter.IdStock);

            if (result is not null)
                IncreaseQuantityOfDetail(parameter, result);
            else
                detailListing.Add(new SaleDetailView()
                {
                    IdStock = parameter.IdStock,
                    ProductName = parameter.Name,
                    ProductDescription = parameter.Description,
                    Presentation = parameter.Presentation,
                    Quantity = 1,
                    Price = parameter.Price,
                    Total = parameter.Price
                });
        }

        private void IncreaseQuantityOfDetail(StockView parameter, SaleDetailView element)
        {
            if (element.Quantity >= parameter.Quantity + 1)
                return;

            element.Quantity++;
            element.Total = element.Quantity * element.Price;

            UpdateDetail(element, detailListing.IndexOf(element));

            if (element.Quantity > parameter.Quantity)
                detailSelected = element;
        }

        private SaleDetailView GetIndexDetail(int idStock) =>
            detailListing.Find(item => item.IdStock == idStock);

        public ICommand deleteDetail => new RelayCommand(parameter =>
        {
            if (parameter is null)
                return;

            detailListing.Remove((SaleDetailView)parameter);
            detailSelected = null;
        });

        public ICommand editDetail => new RelayCommand(parameter =>
        {
            if (parameter is null)
                return;

            if (hasDetailErrors)
            {
                detailErrors.ClearErrors(detailSelected.IdStock.ToString());
                OnPropertyChanged(nameof(canCreateSale));
            }

            var _parameter = (SaleDetailView)parameter;

            _parameter.Quantity = quantity;
            _parameter.Total = _parameter.Price * quantity;

            UpdateDetail(_parameter, detailListing.IndexOf(_parameter));

            detailSelected = null;
        });

        private void UpdateDetail(SaleDetailView parameter, int index)
        {
            detailListing.Remove(parameter);
            detailListing.Insert(index, parameter);
        }

        private SaleDetailView _detailSelected;
        public SaleDetailView detailSelected
        {
            get => _detailSelected;
            set
            {
                _detailSelected = value;

                if (_detailSelected is not null)
                    quantity = _detailSelected.Quantity;

                OnPropertyChanged(nameof(detailSelected));
                OnPropertyChanged(nameof(detailsEditorIsVisible));
            }
        }

        private int _quantity;
        public int quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;

                errorsViewModel.ClearErrors(nameof(quantity));

                if (_quantity < 1)
                {
                    detailErrors.AddError(detailSelected.IdStock.ToString(), "1");
                    errorsViewModel.AddError(nameof(quantity), "Cantidad invalida");
                    OnPropertyChanged(nameof(canCreateSale));
                }
                else
                    VerifyStockQuantity();

                OnPropertyChanged(nameof(quantity));
            }
        }

        private async void VerifyStockQuantity()
        {
            if (!await logic.VerifyStockQuantity(_quantity, detailSelected.IdStock))
            {
                detailErrors.AddError(detailSelected.IdStock.ToString(), "1");
                errorsViewModel.AddError(nameof(quantity), "No hay suficiente cantidad en stock");
                OnPropertyChanged(nameof(canCreateSale));
            }
        }

        private readonly ErrorsViewModel detailErrors = new();

        private bool hasDetailErrors => detailErrors.HasErrors;

        public bool canCreateSale => !hasDetailErrors && (detailListing.Count != 0);

        public bool detailsEditorIsVisible => _detailSelected is not null;

        private ICollection<Discount> _discounts;
        public ICollection<Discount> discounts
        {
            get
            {
                if (_discounts is null)
                    _discounts = new List<Discount>
                    {
                        new(0.0, ""),
                        new(0.05, "5%"),
                        new(0.10, "10%"),
                        new(0.15, "15%")
                    };

                return _discounts;
            }
        }

        private Discount? _selectedDiscoumt = new();
        public Discount? selectedDiscount
        {
            get => _selectedDiscoumt;
            set
            {
                _selectedDiscoumt = value;
                OnPropertyChanged(nameof(selectedDiscount));

                GetDiscount(_selectedDiscoumt);
                discountApplies = false;

                OnPropertyChanged(nameof(discountedAmount));
            }
        }

        private void GetDiscount(Discount? parameter)
        {
            if (parameter is not null)
                discount = ((Discount)parameter).discount;
            else
                discount = 0;
        }

        public double discount { get; private set; }
        public double discountedAmount => discount * _total;

        private bool _discountApplies;
        public bool discountApplies
        {
            get => _discountApplies;
            set
            {
                _discountApplies = value;
                OnPropertyChanged(nameof(discountApplies));

                OnPropertyChanged(nameof(total));
            }
        }

        private void DetailListing_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(total));
            OnPropertyChanged(nameof(canCreateSale));
            OnPropertyChanged(nameof(discountedAmount));
        }
    }

    public struct Discount
    {
        public Discount(double discount, string name)
        {
            this.discount = discount;
            this.name = name;
        }

        public double discount { get; }
        public string name { get; }
    }
}

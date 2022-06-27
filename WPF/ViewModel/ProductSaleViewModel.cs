using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
using Domain.Logic.Base;
using Domain.Services.TransactionServices;
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
using WPF.ViewModel.Utilities;

namespace WPF.ViewModel
{
    public class ProductSaleViewModel : FormViewModel
    {
        public ICommand backCommand { get; }
        private ICommand sellStockCommand { get; }
        public ICommand salesChargeModalCommand { get; }

        public StockViewerViewModel stockViewer { get; }

        private readonly IMessenger messenger;

        private readonly SaleLogic logic;

        public ProductSaleViewModel(
            ILogic _logic,
            IMessenger _messenger,
            IAccountStore _accountStore,
            ISellStockService sellStockService,
            ViewModelBase _stockViewer,
            INavigationService backNavigation,
            INavigationService modalNavigationService)
        {
            backCommand = new NavigateCommand(backNavigation);
            salesChargeModalCommand = new NavigateCommand(modalNavigationService);
            sellStockCommand = new SellStockCommand(this, sellStockService);
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
            messenger.Send(new SaleChargeModalMessage(total, sellStockCommand));
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

        public ObservableCollection<TransactionDetailView> detailListing { get; }

        private bool _stockViewerIsVisible;
        public bool stockViewerIsVisible
        {
            get => _stockViewerIsVisible;
            set
            {
                _stockViewerIsVisible = value;
                OnPropertyChanged(nameof(stockViewerIsVisible));

                if (_stockViewerIsVisible)
                    messenger.Send(TransactionType.sale);
            }
        }

        private void AddDetail(object _parameter)
        {
            var parameter = (StockViewerMessage)_parameter;
            
            if (parameter.transaction is not TransactionType.sale)
                return;

            TransactionDetailView result = GetIndexDetail(parameter.element.IdStock);

            if (result is not null)
                IncreaseQuantityOfDetail(parameter.element, result);
            else
                detailListing.Add(new SaleDetailView()
                {
                    IdStock = parameter.element.IdStock,
                    ProductName = parameter.element.Name,
                    ProductDescription = parameter.element.Description,
                    Presentation = parameter.element.Presentation,
                    Quantity = 1,
                    Price = parameter.element.Price,
                    Total = parameter.element.Price
                });
        }

        private void IncreaseQuantityOfDetail(StockView parameter, TransactionDetailView element)
        {
            if (element.Quantity >= parameter.Quantity + 1)
                return;

            element.Quantity++;
            element.Total = element.Quantity * element.Price;

            UpdateDetail(element, detailListing.IndexOf(element));

            if (element.Quantity > parameter.Quantity)
                detailSelected = (SaleDetailView)element;
        }

        private TransactionDetailView GetIndexDetail(int idStock) =>
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

        private void UpdateDetail(TransactionDetailView parameter, int index)
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

        private Discount _selectedDiscoumt = new();
        public Discount selectedDiscount
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

        private void GetDiscount(Discount parameter) =>
            discount = parameter is not null ? parameter.discount : 0;

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

        public override void Dispose()
        {
            stockViewerIsVisible = false;
            statusMessage = string.Empty;
            base.Dispose();
        }
    }
}

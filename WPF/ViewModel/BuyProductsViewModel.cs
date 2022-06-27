using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
using Domain.Logic.Base;
using Domain.Services.TransactionServices;
using Domain.Utilities;
using MVVMGenericStructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using WPF.Command;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;
using WPF.ViewModel.Utilities;

namespace WPF.ViewModel
{
    public class BuyProductsViewModel : FormViewModel
    {
        public ICommand buyStockCommand => new RelayCommand(o =>
        {
            buyStocksCommand.Execute(null);
        });

        public ICommand buyStocksCommand { get; }

        public StockViewerViewModel stockViewer { get; }

        private readonly IMessenger messenger;

        private readonly PurchaseLogic logic;

        public BuyProductsViewModel(
            ILogic _logic,
            IMessenger _messenger,
            IBuyStockService sellStockService,
            ViewModelBase _stockViewer)
        {
            buyStocksCommand = new BuyStockCommand(this, sellStockService);

            stockViewer = (StockViewerViewModel)_stockViewer;

            logic = (PurchaseLogic)_logic;

            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshListing);
            messenger.Subscribe<StockViewerMessage>(this, AddDetail);

            detailListing = new();
            detailListing.CollectionChanged += DetailListing_Changed;

            providerSelected = null;
            LoadProviders();
        }

        public void Reset()
        {
            ResetProperties();
            messenger.Send(Refresh.purchase);
            messenger.Send(Refresh.stock);
        }

        public ICommand resetCommand => new RelayCommand(o => ResetProperties());

        private void ResetProperties()
        {
            selectedDiscount = null;
            detailListing.Clear();

            OnPropertyChanged(nameof(total));
            OnPropertyChanged(nameof(date));
        }

        public Provider provider { get; }

        private DateTime? _date;
        public DateTime date
        {
            get
            {
                if (_date is null)
                    _date = DateTime.Now;

                return (DateTime)_date;
            }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(date));
            }
        }

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
                    messenger.Send(TransactionType.purchase);
            }
        }

        private void AddDetail(object _parameter)
        {
            var parameter = (StockViewerMessage)_parameter;

            if (parameter.transaction is not TransactionType.purchase)
                return;

            TransactionDetailView result = GetIndexDetail(parameter.element.IdStock);

            if (result is not null)
                IncreaseQuantityOfDetail(result);
            else
            {
                detailListing.Add(new SupplyDetailView()
                {
                    IdStock = parameter.element.IdStock,
                    ProductName = parameter.element.Name,
                    ProductDescription = parameter.element.Description,
                    Presentation = parameter.element.Presentation,
                    Quantity = 1,
                    Price = 0,
                    Total = 0
                });

                detailSelected = (SupplyDetailView)GetIndexDetail(parameter.element.IdStock);
            }
        }

        private void IncreaseQuantityOfDetail(TransactionDetailView element)
        {
            element.Quantity++;
            element.Total = element.Quantity * element.Price;

            UpdateDetail(element, detailListing.IndexOf(element));
        }

        private TransactionDetailView GetIndexDetail(int idStock) =>
            detailListing.Find(item => item.IdStock == idStock);

        public ICommand deleteDetail => new RelayCommand(parameter =>
        {
            if (parameter is null)
                return;

            detailListing.Remove((SupplyDetailView)parameter);
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

            var _parameter = (SupplyDetailView)parameter;

            _parameter.Quantity = quantity;
            _parameter.Price = price;
            _parameter.Total = _parameter.Price * quantity;

            UpdateDetail(_parameter, detailListing.IndexOf(_parameter));

            detailSelected = null;
        });

        private void UpdateDetail(TransactionDetailView parameter, int index)
        {
            detailListing.Remove(parameter);
            detailListing.Insert(index, parameter);
        }

        private SupplyDetailView _detailSelected;
        public SupplyDetailView detailSelected
        {
            get => _detailSelected;
            set
            {
                _detailSelected = value;

                if (_detailSelected is not null)
                {
                    price = _detailSelected.Price;
                    quantity = _detailSelected.Quantity;
                }

                OnPropertyChanged(nameof(detailSelected));
                OnPropertyChanged(nameof(detailsEditorIsVisible));
            }
        }

        private double _price;
        public double price
        {
            get => _price;
            set
            {
                _price = value;

                errorsViewModel.ClearErrors(nameof(price));

                if (_price < 1)
                {
                    detailErrors.AddError(detailSelected.IdStock.ToString(), "1");

                    if (_price == 0)
                        errorsViewModel.AddError(nameof(price), "Ingresa un precio de compra");
                    else
                        errorsViewModel.AddError(nameof(price), "Precio invalido");

                    OnPropertyChanged(nameof(canCreateSale));
                }

                OnPropertyChanged(nameof(price));
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

                OnPropertyChanged(nameof(quantity));
            }
        }

        private readonly ErrorsViewModel detailErrors = new();

        private bool hasDetailErrors => detailErrors.HasErrors;

        public bool canCreateSale => !hasDetailErrors && (detailListing.Count != 0);

        public bool detailsEditorIsVisible => _detailSelected is not null;

        private void RefreshListing(object parameter)
        {
            if (parameter is not Refresh.provider)
                return;

            LoadProviders();
        }

        private async void LoadProviders()
        {
            providerListing = new();
            providerSelected = null;

            var list = (await logic.GetProviders()).Where(item => item.idProvider > 0);

            foreach (var (name, idProvider) in list)
                providerListing.Add(new { name = name, idProvider = idProvider });
        }

        private List<dynamic> _providerListing;
        public List<dynamic> providerListing
        {
            get => _providerListing;
            set
            {
                _providerListing = value;
                OnPropertyChanged(nameof(providerListing));
            }
        }

        private dynamic _providerSelected;
        public dynamic providerSelected
        {
            get
            {
                errorsViewModel.ClearErrors(nameof(providerSelected));

                if (_providerSelected is null)
                    errorsViewModel.AddError(nameof(providerSelected), "Seleccione un proveedor");

                return _providerSelected;
            }
            set
            {
                _providerSelected = value;
                OnPropertyChanged(nameof(providerSelected));
            }
        }

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
            discount = parameter is null ? 0 : parameter.discount;

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

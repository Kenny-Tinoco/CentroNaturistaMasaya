using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
using Domain.Logic.Base;
using Domain.Utilities;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class ProductSaleViewModel : FormViewModel
    {
        public ICommand backCommand { get; }

        public ICommand openModalCommand { get; }

        private readonly SaleLogic logic;

        private readonly SearchBarViewModel searchViewModel;

        private readonly IMessenger messenger;

        private readonly IAccountStore accountStore;

        public ProductSaleViewModel(ILogic _logic, IMessenger _messenger, INavigationService backNavigation, INavigationService openModal, IAccountStore _accountStore)
        {
            backCommand = new NavigateCommand(backNavigation);
            openModalCommand = new NavigateCommand(openModal);
            accountStore = _accountStore;

            searchViewModel = new(StockViewFilter);

            logic = (SaleLogic)_logic;

            messenger = _messenger;
            messenger.Subscribe<SaveSale>(this, TheSaleEnds);

            detailListing.CollectionChanged += DetailListing_Changed;

            InitializeDiscounts();
        }


        private void TheSaleEnds(object parameter)
        {
            var message = (SaveSale)parameter;
            if (message is SaveSale.save)
                Save();
        }

        private void InitializeDiscounts()
        {
            discounts = new List<Discount>
            {
                new Discount(0.0, ""),
                new Discount(0.05, "5%"),
                new Discount(0.10, "10%"),
                new Discount(0.15, "15%")
            };
        }

        private void DetailListing_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(total));
            OnPropertyChanged(nameof(canCreateSale));
            OnPropertyChanged(nameof(discountInCordobas));
        }

        private void ResetValuesToProperties()
        {
            detailListing.Clear();
            entity = null;
            selectedDiscount = null;

            OnPropertyChanged(nameof(total));
        }

        public ICommand finishSaleCommand => new RelayCommand(o =>
        {
            messenger.Send(new SaleChargeModalMessage(total));
            openModalCommand.Execute(null);
        });

        private async void Save()
        {
            await RunSaveCommand();

            messenger.Send(Refresh.sale);
            messenger.Send(Refresh.stock);
            ResetValuesToProperties();
            LoadTheProducts();
        }

        private async Task RunSaveCommand()
        {
            logic.entity = GetSale();
            await new SaveCommand(logic, this).ExecuteAsync(false);
        }

        private Sell GetSale()
        {
            var element = new Sell()
            {
                IdEmployee = employee.IdEmployee,
                Date = date,
                Discount = _discount,
                Total = entity.Total
            };

            var details = GetDetail();

            foreach (var _item in details)
                element.SaleDetails.Add(_item);

            return element;
        }

        private List<SaleDetail> GetDetail()
        {
            List<SaleDetail> list = new();

            list.AddRange(detailListing.Select(item => new SaleDetail()
            {
                IdStock = item.IdStock,
                Quantity = item.Quantity,
                Price = item.Price,
                Total = item.Total
            }));

            return list;
        }

        public string text
        {
            get => searchViewModel.text;
            set => searchViewModel.text = value;
        }

        private bool StockViewFilter(object parameter, string text)
        {
            if (parameter is not StockView)
                return false;

            return StockLogic.SearchLogic((StockView)parameter, text);
        }

        private Sell _entity;
        private Sell entity
        {
            get
            {
                if (_entity is null)
                    _entity = new Sell();
                return _entity;
            }
            set => _entity = value;
        }

        private double _total;
        public double total
        {
            get
            {
                _total = 0;

                foreach (var item in detailListing)
                    _total += item.Total;

                entity.Total = (1 - _discount) * _total;

                return entity.Total;
            }
            set
            {
                entity.Total = value;
                OnPropertyChanged(nameof(total));
            }
        }

        public DateTime date
        {
            get
            {
                entity.Date = DateTime.Now;
                return entity.Date;
            }
            set
            {
                entity.Date = value;
                OnPropertyChanged(nameof(date));
            }
        }

        public Employee employee => accountStore.currentAccount.EmployeeNavigation;


        public ICommand searchProductsInTheSelector => new RelayCommand(o => SearchProductsInTheSelector());

        private void SearchProductsInTheSelector()
        {
            productSelectorIsVisible = !productSelectorIsVisible;
        }

        private ObservableCollection<SaleDetailView> _detailListing;
        public ObservableCollection<SaleDetailView> detailListing
        {
            get
            {
                if (_detailListing is null)
                    _detailListing = new ObservableCollection<SaleDetailView>();

                return _detailListing;
            }
        }

        private bool _productSelectorIsVisible;
        public bool productSelectorIsVisible
        {
            get => _productSelectorIsVisible;
            set
            {
                _productSelectorIsVisible = value;
                OnPropertyChanged(nameof(productSelectorIsVisible));
            }
        }

        private StockView _stockSelected;
        public StockView stockSelected
        {
            get => _stockSelected;
            set
            {
                _stockSelected = value;
                OnPropertyChanged(nameof(stockSelected));
            }
        }

        private IEnumerable<StockView> _stockListing;
        public IEnumerable<StockView> stockListing
        {
            get => _stockListing;
            set
            {
                _stockListing = value;
                OnPropertyChanged(nameof(stockListing));
                OnPropertyChanged(nameof(hasStockListing));
            }
        }

        private ICollectionView _listing;
        private ICollectionView listing
        {
            get
            {
                if (_listing is null)
                    _listing = CollectionViewSource.GetDefaultView(stockListing);

                return _listing;
            }
        }
        private void Sort()
        {
            listing.SortDescriptions
                .Clear();

            listing.SortDescriptions
                .Add(new SortDescription(nameof(StockView.Name), ListSortDirection.Ascending));
        }

        private ObservableCollection<Presentation> _presentations;
        public ObservableCollection<Presentation> presentations
        {
            get
            {
                if (_presentations is null)
                    _presentations = new ObservableCollection<Presentation>();

                return _presentations;
            }
            set
            {
                _presentations = value;
                OnPropertyChanged(nameof(presentations));
            }
        }

        private Presentation _presentationSelected;
        public Presentation presentationSelected
        {
            get => _presentationSelected;
            set
            {
                _presentationSelected = value;

                if (_presentationSelected is not null)
                    searchViewModel.text = _presentationSelected.Name;

                OnPropertyChanged(nameof(presentationSelected));
            }
        }


        private ICommand _addProductToDetail;
        public ICommand addProductToDetail
        {
            get
            {
                if (_addProductToDetail is null)
                    _addProductToDetail = new RelayCommand(parameter => AddProductToDetail((StockView)parameter));
                return _addProductToDetail;
            }
        }

        private void AddProductToDetail(StockView parameter)
        {
            if (parameter is null)
                return;

            int index = GetIndexDetailOf(parameter.IdStock);

            if (index != -1)
            {
                var item = detailListing[index];

                if (item.Quantity >= parameter.Quantity + 1)
                    return;

                item.Quantity++;
                item.Total = item.Quantity * item.Price;

                detailListing.RemoveAt(index);
                detailListing.Insert(index, item);

                if (item.Quantity > parameter.Quantity)
                    detailSelected = item;

                return;
            }

            var element = new SaleDetailView()
            {
                IdStock = parameter.IdStock,
                ProductName = parameter.Name,
                ProductDescription = parameter.Description,
                Presentation = parameter.Presentation,
                Quantity = 1,
                Price = parameter.Price
            };

            element.Total = element.Quantity * element.Price;

            detailListing.Add(element);
        }

        private int GetIndexDetailOf(int idStock)
        {
            SaleDetailView element = null;

            element = detailListing.Find(item => item.IdStock == idStock);
            if (element is null)
                return -1;

            var i = detailListing.IndexOf(element);
            return i;
        }

        public ICommand closeSelector => new RelayCommand(o => productSelectorIsVisible = false);


        private ICommand _deleteDetail;
        public ICommand deleteDetail
        {
            get
            {
                if (_deleteDetail is null)
                    _deleteDetail = new RelayCommand(parameter => DeleteDetail((SaleDetailView)parameter));
                return _deleteDetail;
            }
        }

        private void DeleteDetail(SaleDetailView parameter)
        {
            if (parameter is null)
                return;

            detailListing.Remove(parameter);
            detailSelected = null;
        }


        private ICommand _editDetail;
        public ICommand editDetail
        {
            get
            {
                if (_editDetail is null)
                    _editDetail = new RelayCommand(parameter => EditDetail((SaleDetailView)parameter));
                return _editDetail;
            }
        }

        private void EditDetail(SaleDetailView parameter)
        {
            if (parameter is null)
                return;

            if (hasDetailErrors)
            {
                detailErrors.ClearErrors(detailSelected.IdStock.ToString());
                OnPropertyChanged(nameof(canCreateSale));
            }

            parameter.Quantity = quantity;
            parameter.Total = parameter.Price * quantity;

            var index = detailListing.IndexOf(parameter);

            detailListing.Remove(parameter);
            detailListing.Insert(index, parameter);
            detailSelected = null;
        }


        private SaleDetailView _detailSelected;
        public SaleDetailView detailSelected
        {
            get => _detailSelected;
            set
            {
                _detailSelected = value;

                if (_detailSelected is not null)
                { 
                    quantity = _detailSelected.Quantity;
                }

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

        private bool _detailsEditorIsVisible;
        public bool detailsEditorIsVisible
        {
            get
            {
                _detailsEditorIsVisible = _detailSelected != null;
                return _detailsEditorIsVisible;
            }
            set
            {
                _detailsEditorIsVisible = value;
                OnPropertyChanged(nameof(detailsEditorIsVisible));
            }
        }

        public ICollection<Discount> discounts { get; private set; }

        public ICommand loadTheProducts => new RelayCommand(o => LoadTheProducts());

        private async void LoadTheProducts()
        {
            isLoading = true;
            stockListing = null;
            stockListing = await logic.GetStockListing();
            Sort();

            var presentationList = await logic.GetPresentationListing();

            presentations.Clear();
            foreach (var item in presentationList)
                presentations.Add(item);

            isLoading = false;

            searchViewModel.listing = listing;
        }

        private bool _isLoading;
        public bool isLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(isLoading));
            }
        }
        public bool hasStockListing => stockListing != null;

        public double discountInCordobas
        {
            get
            {
                double aux;
                if (_discount == 0 && _discountAux != 0)
                    aux = _discountAux * _total;
                else
                    aux = _discount * _total;

                return aux;
            }
            private set { }
        }

        private Discount _selectedDiscoumt = new();
        public Discount selectedDiscount
        {
            get => _selectedDiscoumt;
            set
            {
                _selectedDiscoumt = value;
                GetDiscount(_selectedDiscoumt);
                OnPropertyChanged(nameof(selectedDiscount));
            }
        }
        private void GetDiscount(Discount parameter)
        {
            if (parameter is null)
                return;

            _discount = parameter.discount;
            _discountAux = 0;
            OnPropertyChanged(nameof(discountInCordobas));
        }

        private double _discount = 0;
        private double _discountAux;

        public ICommand applyDiscountCommand => new RelayCommand(parameter =>
        {
            var isChecked = (bool)parameter;

            if (!isChecked)
            {
                _discountAux = _discount;
                _discount = 0;
            }
            else
                if (_discountAux != 0)
                _discount = _discountAux;

            OnPropertyChanged(nameof(total));
            if (_discount != 0)
                OnPropertyChanged(nameof(discountInCordobas));
        });
    }
}

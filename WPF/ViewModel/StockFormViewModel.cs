using Domain.Entities;
using Domain.Logic;
using Domain.Utilities;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Stores;
using WPF.ViewComponents.Converters;

namespace WPF.ViewModel
{
    public class StockFormViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        public string title => !isEdition ?
            "Agregar una nueva existencia" :
            "Editar existencia";

        public ICommand BackCommand { get; }
        public ICommand SearchCommand { get; }

        private BaseLogic<Product> productLogic;
        private BaseLogic<Presentation> presentationLogic;
        private BaseLogic<Stock> stockLogic;

        public EntityStore entityStore { get; }

        private StockFormViewModel(LogicFactory logic, EntityStore _entityStore, INavigationService backNavigation, INavigationService modalNavigation)
        {
            BackCommand = new NavigateCommand(backNavigation);
            SearchCommand = new NavigateCommand(modalNavigation);

            stockLogic = logic.stockLogic;
            productLogic = logic.productLogic;
            presentationLogic = logic.presentationModalLogic;

            _errorsViewModel = new ErrorsViewModel();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            entityStore = _entityStore;
            entityStore.Refresh += RefreshChanges;
            entityStore.EntitySelected += OnEntitySelected;
        }



        public static StockFormViewModel LoadViewModel(LogicFactory logic, EntityStore _entityStore, INavigationService backNavigation, INavigationService modalNavigation)
        {
            StockFormViewModel _viewModel = new StockFormViewModel(logic, _entityStore, backNavigation, modalNavigation);

            _viewModel.Initialize();
            return _viewModel;
        }

        public async void Initialize()
        {
            presentations = await presentationLogic.getAll();
            entityStore._catalogue = await productLogic.getAll();

            OnPropertyChanged(nameof(entityStore._catalogue));
            IniatilizeEntity();
        }

        private void IniatilizeEntity()
        {

            if (entityStore.entity is null)
                resetValuesToProperties();
            else
                setValuesToProperties((Stock)entityStore.entity);
        }

        private ICommand _selectImageCommand;
        public ICommand SelectImageCommand
        {
            get
            {
                if (_selectImageCommand is null)
                    _selectImageCommand = new RelayCommand(parameter => selectImage());

                return _selectImageCommand;
            }
        }
        private void selectImage()
        {
            var imageSelected = Converters.GetImage();
            
            if (imageSelected is not null)
                image = imageSelected;

            OnPropertyChanged(nameof(image));
        }

        private void resetValuesToProperties()
        {
            price = 0;
            quantity = 1;
            entryDate = DateTime.Now;
            expiration = nextYear(DateTime.Now);
            status = true;
            image = new byte[1];

            currentProduct = null;
            currentPresentation = presentations.Find(item => item.IdPresentation == 11);
        }

        private DateTime nextYear(DateTime today) => new DateTime(today.Year+1, today.Month, today.Day + 1);


        public ICommand SaveCommand => new RelayCommand(parameter => save((bool)parameter));
        private void save(bool isEdtion)
        {
            stockLogic.entity = getStock();

            new SaveCommand<Stock>(stockLogic, canCreate).Execute(isEdtion);
            entityStore.RefreshStockChanges();
            resetValuesToProperties();

            if (isEdtion)
                BackCommand.Execute(-1);
        }

        private Stock getStock()
        {
            return new Stock()
            {
                IdStock = ((Stock)entityStore.entity).IdStock,
                IdProduct = currentProduct.IdProduct,
                IdPresentation = currentPresentation.IdPresentation,
                Price = price,
                Quantity = quantity,
                EntryDate = entryDate,
                Expiration = expiration,
                Status = status,
                Image = image
            };
        }


        private void OnEntitySelected(BaseEntity parameter)
        {
            currentProduct = (Product)parameter;
        }

        private void setValuesToProperties(Stock parameter)
        {
            price = parameter.Price;
            quantity = parameter.Quantity;
            status = parameter.Status;
            image = parameter.Image;
            insertDates(parameter);

            currentProduct = parameter.ProductNavigation;
            currentPresentation = presentations.Find(item => item.IdPresentation == parameter.IdPresentation);
        }

        private void insertDates(Stock parameter)
        {
            try
            {
                entryDate = (DateTime)parameter.EntryDate;
                expiration = (DateTime)parameter.Expiration;
            }
            catch
            {
                if (parameter.EntryDate == null && parameter.Expiration == null)
                {
                    entryDate = DateTime.Now;
                    expiration = nextYear(DateTime.Now);
                }
                else if (parameter.EntryDate == null)
                {
                    entryDate = DateTime.Now;
                    expiration = (DateTime)parameter.Expiration;
                }
                else
                {
                    entryDate = (DateTime)parameter.EntryDate;
                    expiration = nextYear(DateTime.Now);
                }
            }
        }

        private void RefreshChanges()
        {
            Initialize();
        }


        private double _price;
        public double price
        {
            get
            {
                if (_price == 0)
                    _errorsViewModel.AddError(nameof(price), "Ingrese un precio");

                return _price;
            }
            set
            {
                _price = value;
                _errorsViewModel.ClearErrors(nameof(price));

                if (_price == 0)
                    _errorsViewModel.AddError(nameof(price), "Ingrese un precio");
                else if (_price < 0)
                    _errorsViewModel.AddError(nameof(price), "Ingrese un precio positivo");

                OnPropertyChanged(nameof(price));
            }
        }


        private int _quantity;
        public int quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(quantity));
            }
        }


        private DateTime _entryDate;
        public DateTime entryDate
        {
            get
            {
                return _entryDate;
            }
            set
            {
                _entryDate = value;

                _errorsViewModel.ClearErrors(nameof(expiration));
                _errorsViewModel.ClearErrors(nameof(entryDate));

                if (!HasStartDateBeforeEndDate)
                {
                    _errorsViewModel.AddError(nameof(entryDate), "La fecha de entrada no puede ser despues de la expiración");
                }
                else if (_entryDate == _expiration)
                    _errorsViewModel.AddError(nameof(entryDate), "La fecha de entrada no puede ser igual a la expiración");

                OnPropertyChanged(nameof(entryDate));
            }
        }


        private DateTime _expiration;
        public DateTime expiration
        {
            get
            {
                return _expiration;
            }
            set
            {
                _expiration = value;

                _errorsViewModel.ClearErrors(nameof(expiration));
                _errorsViewModel.ClearErrors(nameof(entryDate));

                if (!HasStartDateBeforeEndDate)
                {
                    _errorsViewModel.AddError(nameof(expiration), "La fecha de expiración no puede ser antes de la fecha de entrada.");
                }
                else if (_entryDate == _expiration)
                    _errorsViewModel.AddError(nameof(expiration), "La fecha de expiración no puede ser igual a entrada");

                OnPropertyChanged(nameof(expiration));
            }
        }


        private bool _status;
        public bool status
        {
            get => _status;
            private set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(status));
                }
            }
        }

        public ICommand ChangeStatusCommand => new RelayCommand(parameter => chageStatus());

        private void chageStatus()
        {
            bool flag = status;

            if (status)
            {
                var result = MessageBox
                    .Show("¿Está seguro de desactivar esta existencia?\nTodas las ocurrencias del mismo serán ocultadas en los catalogos donde aparezca", "Confirmar desactivación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) status = false;
            }
            else
                status = true;

            if (flag != status && entityStore.isEdition)
            {
                stockLogic.entity = getStock();
                new SaveCommand<Stock>(stockLogic, canCreate).Execute(true);
            }
        }


        private byte[] _image;
        public byte[] image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(image));
            }
        }


        private Product _currentProduct;
        public Product currentProduct
        {
            get
            {
                _errorsViewModel.ClearErrors(nameof(productName));
                if (_currentProduct == null)
                    _errorsViewModel.AddError(nameof(productName), "Elija un producto. Utilize la opción 'Búscar Producto'");

                return _currentProduct;
            }
            set
            {
                if (value != null)
                    _errorsViewModel.ClearErrors(nameof(productName));

                _currentProduct = value;
                OnPropertyChanged(nameof(currentProduct));
                OnPropertyChanged(nameof(productName));
            }
        }
        public string productName => (_currentProduct is null) ? "" : _currentProduct.Name;


        private Presentation _currentPresentation;
        public Presentation currentPresentation
        {
            get
            {
                _errorsViewModel.ClearErrors(nameof(currentPresentation));
                if (_currentPresentation == null)
                    _errorsViewModel.AddError(nameof(currentPresentation), "Elija una presentación");

                return _currentPresentation;
            }
            set
            {
                _currentPresentation = value;
                OnPropertyChanged(nameof(currentPresentation));
            }
        }



        private IEnumerable<Presentation> _presentations;
        public IEnumerable<Presentation> presentations
        {
            get => _presentations;
            set
            {
                _presentations = value;
                OnPropertyChanged(nameof(presentations));
            }
        }


        public bool isEdition => entityStore.isEdition;
        public bool HasErrors => _errorsViewModel.HasErrors;
        public virtual bool canCreate => !HasErrors && HasStartDateBeforeEndDate;
        private bool HasStartDateBeforeEndDate => _entryDate <= _expiration;


        private ErrorsViewModel _errorsViewModel;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(canCreate));
        }

        public override void Dispose()
        {
            entityStore.entity = null;
            entityStore.EntitySelected += null;
            base.Dispose();
        }
    }
}

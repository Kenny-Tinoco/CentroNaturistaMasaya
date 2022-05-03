using Domain.Entities;
using Domain.Logic;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using WPF.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WPF.Command.Navigation;
using WPF.Command.CRUD;

namespace WPF.ViewModel
{
    public class StockFormViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        public string title { get; }

        public ICommand BackCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SearchCommand { get; }

        private BaseLogic<Product> productLogic;
        private BaseLogic<Presentation> presentationLogic;
        private BaseLogic<Stock> stockLogic;

        public EntityStore entityStore { get; }

        private StockFormViewModel( LogicFactory logic,EntityStore _entityStore, INavigationService backNavigation, INavigationService modalNavigation )
        {
            title = "Agregar una nueva existencia";
            BackCommand = new NavigateCommand(backNavigation);
            SearchCommand = new NavigateCommand(modalNavigation);

            stockLogic = logic.stockLogic;
            productLogic = logic.productLogic;
            presentationLogic = logic.presentationModalLogic;

            entityStore = _entityStore;
            entityStore.EntitySelected += OnEntitySelected;
            entityStore.Refresh += RefreshChanges; 

            if (entityStore.entity != null)
                entity = (Stock)entityStore.entity;
            else
                resetEntity();

            _errorsViewModel = new ErrorsViewModel();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            SaveCommand = new RelayCommand(parameter => save(parameter));
        }

        private void resetEntity()
        {
            var element = new Stock()
            {
                idStock = 0,
                idPresentation = 0,
                idProduct = 0,
                price = 0,
                quantity = 1,
                entryDate = DateTime.Now,
                expiration = tomorrow(DateTime.Now)
            };

            entity = element;
        }

        private DateTime? tomorrow(DateTime today)
        {
            return new DateTime(today.Year, today.Month, today.Day+1);
        }

        private void save(object parameter)
        {
            entity.idProduct = currentProduct.idProduct;
            entity.idPresentation = currentPresentation.idPresentation; 

            stockLogic.entity = entity;
            
            new SaveCommand<Stock>(stockLogic, canCreate).Execute(parameter);
            entityStore.RefreshChanges();
            resetControls();
        }

        private void resetControls()
        {
            resetEntity();
            price = entity.price;
            quantity = entity.quantity;
            entryDate = (DateTime)entity.entryDate;
            expiration = (DateTime)entity.expiration;

            currentPresentation = new Presentation();
            currentProduct = new Product();
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

            var auxiliaryList = new ObservableCollection<BaseEntity>();
            (await productLogic.getAll()).ToList().ForEach(element => auxiliaryList.Add(element));

            entityStore._catalogue = auxiliaryList;
            OnPropertyChanged(nameof(entityStore._catalogue));
        }


        private void OnEntitySelected(BaseEntity parameter)
        {
            currentProduct = ((Product)parameter);
        }
        private void RefreshChanges()
        {
            Initialize();
        }


        public string productName
        {
            get
            {
                if (_currentProduct == null)
                    return "";
                return _currentProduct.name;
            }
        }
        
        public double price
        {
            get
            {
                if (entity.price == 0)
                    _errorsViewModel.AddError(nameof(price), "Ingrese un precio");

                return entity.price;
            }
            set
            {
                entity.price = value;
                _errorsViewModel.ClearErrors(nameof(price));

                if (entity.price == 0)
                    _errorsViewModel.AddError(nameof(price), "Ingrese un precio");
                else if (entity.price < 0)
                    _errorsViewModel.AddError(nameof(price), "Ingrese un precio positivo");

                OnPropertyChanged(nameof(price));
            }
        }

        public int quantity
        {
            get
            {
                return entity.quantity;
            }
            set
            {
                entity.quantity = value;
                OnPropertyChanged(nameof(quantity));
            }
        }

        public DateTime entryDate
        {
            get
            {
                return (DateTime)entity.entryDate;
            }
            set
            {
                entity.entryDate = value;

                _errorsViewModel.ClearErrors(nameof(expiration));
                _errorsViewModel.ClearErrors(nameof(entryDate));

                if (!HasStartDateBeforeEndDate)
                {
                    _errorsViewModel.AddError(nameof(entryDate),"La fecha de entrada no puede ser despues de la expiración");
                }
                else if (entity.entryDate == entity.expiration)
                    _errorsViewModel.AddError(nameof(entryDate), "La fecha de entrada no puede ser igual a la expiración");

                OnPropertyChanged(nameof(entryDate));
            }
        }

        public DateTime expiration
        {
            get
            {
                return (DateTime)entity.expiration;
            }
            set
            {
                entity.expiration = value;

                _errorsViewModel.ClearErrors(nameof(expiration));
                _errorsViewModel.ClearErrors(nameof(entryDate));

                if (!HasStartDateBeforeEndDate)
                {
                    _errorsViewModel.AddError(nameof(expiration),"La fecha de expiración no puede ser antes de la fecha de entrada.");
                }
                else if (entity.entryDate == entity.expiration)
                    _errorsViewModel.AddError(nameof(expiration), "La fecha de expiración no puede ser igual a entrada");

                OnPropertyChanged(nameof(expiration));
            }
        }



        public bool isEdition => entityStore.isEdition;
        public bool HasErrors => _errorsViewModel.HasErrors;
        public virtual bool canCreate => !HasErrors && HasStartDateBeforeEndDate;
        private bool HasStartDateBeforeEndDate => (DateTime)entity.entryDate <= (DateTime)entity.expiration;


        private ErrorsViewModel _errorsViewModel;


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

        private Stock _entity;
        public Stock entity
        {
            get => _entity;
            set
            {
                _entity = value;
                OnPropertyChanged(nameof(entity));
            }
        }


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
            entityStore.EntitySelected -= OnEntitySelected;
            base.Dispose();
        }
    }
}

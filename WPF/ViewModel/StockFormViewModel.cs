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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewComponents.Converters;

namespace WPF.ViewModel
{
    public class StockFormViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        public string title => isEdition ? "Editar existencia" : "Agregar una nueva existencia";

        public ICommand BackCommand { get; }
        public ICommand SearchCommand { get; }

        private LogicFactory logicFactory;

        public IMessenger messenger;
        private StockMessage message;

        private StockFormViewModel(LogicFactory logic, IMessenger _messenger, INavigationService backNavigation, INavigationService modalNavigation)
        {
            BackCommand = new NavigateCommand(backNavigation);
            SearchCommand = new NavigateCommand(modalNavigation);

            logicFactory = logic;

            _errorsViewModel = new ErrorsViewModel();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshPresentation);
            messenger.Subscribe<Product>(this, ProductMessageSent);
            messenger.Subscribe<StockMessage>(this, StockMessageSent);
        }

        private async void RefreshPresentation(object parameter)
        {
            if ((Refresh)parameter is not Refresh.presentation)
                return;

            presentations = await logicFactory.presentationModalLogic.GetActives();
        }

        private void ProductMessageSent(object parameter)
        {
            currentProduct = (Product)parameter;
        }

        private void StockMessageSent(object parameter)
        {
            message = (StockMessage)parameter;
        }

        public static StockFormViewModel LoadViewModel(LogicFactory logic, IMessenger _messenger, INavigationService backNavigation, INavigationService modalNavigation)
        {
            StockFormViewModel _viewModel = new(logic, _messenger, backNavigation, modalNavigation);
            _viewModel.Initialize();

            return _viewModel;
        }

        public async void Initialize()
        {
            presentations = await logicFactory.presentationModalLogic.GetActives();
            var catalogue = await logicFactory.productLogic.GetActives();

            messenger.Send(catalogue);
            InitializeProperties(message.entity);
        }

        private void InitializeProperties(Stock parameter)
        {
            if (parameter is null)
                ResetValuesToProperties();
            else
                SetValuesToProperties(parameter);
        }

        private ICommand _selectImageCommand;
        public ICommand SelectImageCommand
        {
            get
            {
                if (_selectImageCommand is null)
                    _selectImageCommand = new RelayCommand(o => GetImage());

                return _selectImageCommand;
            }
        }
        private void GetImage()
        {
            var imageSelected = Utilities.GetImage();

            if (imageSelected is not null)
                image = imageSelected;

            OnPropertyChanged(nameof(image));
        }

        private void ResetValuesToProperties()
        {
            price = 0;
            quantity = 1;
            entryDate = DateTime.Now;
            expiration = DateTime.Now.PlusOneYear();
            status = true;
            image = new byte[1];

            currentProduct = null;
            currentPresentation = presentations.Find(item => item.IdPresentation == 11);
        }

        public ICommand SaveCommand => new RelayCommand(parameter => Save((bool)parameter));
        private async void Save(bool isEdtion)
        {
            RunSaveCommand(isEdition);

            messenger.Send(Refresh.stock);
            ResetValuesToProperties();

            notification = "Guardado con éxito";

            if (isEdtion)
                BackCommand.Execute(-1);
            else
            {
                await Task.Delay(3000);
                notification = "";
            }
        }

        private Stock GetStock()
        {
            return new Stock()
            {
                IdStock = message.isEdition ? message.entity.IdStock : 0,
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

        private void SetValuesToProperties(Stock parameter)
        {
            price = parameter.Price;
            quantity = parameter.Quantity;
            status = parameter.Status;
            image = parameter.Image;
            InsertDates(parameter);

            currentProduct = parameter.ProductNavigation;
            currentPresentation = presentations.Find(item => item.IdPresentation == parameter.IdPresentation);
        }

        private void InsertDates(Stock parameter)
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
                    expiration = DateTime.Now.PlusOneYear();
                }
                else if (parameter.EntryDate == null)
                {
                    entryDate = DateTime.Now;
                    expiration = (DateTime)parameter.Expiration;
                }
                else
                {
                    entryDate = (DateTime)parameter.EntryDate;
                    expiration = DateTime.Now.PlusOneYear();
                }
            }
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

                if (!hasEntryDateBeforeExpiration)
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

                if (!hasEntryDateBeforeExpiration)
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


        public ICommand ChangeStatusCommand => new RelayCommand(o => ChangeStatus());

        private async void ChangeStatus()
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

            if (flag != status && isEdition)
            {
                RunSaveCommand(true);
                messenger.Send(Refresh.stock);

                notification = "Cambio de estado guardado con éxito";
                await Task.Delay(3000);
                notification = "";
            }
        }

        private void RunSaveCommand(bool isEdition)
        {
            logicFactory.stockLogic.entity = GetStock();
            new SaveCommand<Stock>(logicFactory.stockLogic, canCreate).Execute(isEdition);
        }


        public bool hasChangeableState => logicFactory.stockLogic.hasChangeableState(message.entity.IdStock) && isEdition;
        public string changeableStateMessageError => !hasChangeableState ?
            "No se puede editar esta existencia debido a que el producto y/o la presentación no existen." +
            " \n\nVerifique que dichas entidades estén activadas." : "";


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


        public bool isEdition => message.isEdition;
        public bool HasErrors => _errorsViewModel.HasErrors;
        public virtual bool canCreate => !HasErrors && hasEntryDateBeforeExpiration;
        private bool hasEntryDateBeforeExpiration => _entryDate <= _expiration;

        private string _notification;
        public string notification
        {
            get => _notification;
            set
            {
                _notification = value;
                OnPropertyChanged(nameof(notification));
            }
        }




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
    }
}

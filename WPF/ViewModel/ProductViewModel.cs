using Domain.Entities;
using Domain.Logic;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;

namespace WPF.ViewModel
{
    public class ProductViewModel : ViewModelGeneric<Product>
    {
        public INavigationService _navigationService;

        private ICommand OpenModalCommand { get; }

        private IMessenger messenger;
        private productMessage message; 


        public ProductViewModel(BaseLogic<Product> parameter, IMessenger _messenger, INavigationService modalNavigationService) : base((ProductLogic)parameter)
        {
            _navigationService = modalNavigationService;
            OpenModalCommand = new NavigateCommand(_navigationService);

            AddModalCommand = new RelayCommand(o => AddModal());
            EditModalCommand = new RelayCommand(parameter => EditModal((Product)parameter));

            messenger = _messenger;
            messenger.Subscribe<productModalMessage>(this, MessageReceived);
        }


        public static ProductViewModel LoadViewModel(BaseLogic<Product> parameter, IMessenger messenger, INavigationService navigationService)
        {
            ProductViewModel viewModel = new ProductViewModel(parameter, messenger, navigationService);

            viewModel.loadCatalogueCommand.Execute(null);

            return viewModel;
        }

        private string _searchText;
        public string searchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                search();
            }
        }

        public void search()
        {
            if (ValidateSearchString(searchText))
            {
                dataGridSource.Filter = Filter;
            }
            else if (searchText.Equals(""))
            {
                dataGridSource.Filter = null;
            }
        }

        private bool Filter(object obj)
        {
            if (obj is Product element)
            {
                return ((ProductLogic)logic).searchLogic(element, searchText);
            }

            return false;
        }

        private ICollectionView _dataGridSource;
        public ICollectionView dataGridSource
        {
            get
            {
                if(_dataGridSource != null)
                    Sort();

                return _dataGridSource;
            }
            set
            {
                _dataGridSource = value;
                OnPropertyChanged(nameof(dataGridSource));
            }
        }

        private void Sort()
        {
            _dataGridSource.SortDescriptions
                .Clear();
            _dataGridSource.SortDescriptions
                .Add(new SortDescription(nameof(Product.IdProduct), ListSortDirection.Descending));
        }

        public ICommand AddModalCommand { get; }
        public void AddModal()
        {
            message = new productMessage(null, false);
            messenger.Send(message);

            OpenModalCommand.Execute(-1);
        }


        public ICommand EditModalCommand { get; }
        public void EditModal(Product parameter)
        {
            message = new productMessage(parameter, true);
            messenger.Send(message);

            OpenModalCommand.Execute(-1);
        }


        private ICommand _changeStatusCommand;
        public ICommand ChangeStatusCommand
        {
            get
            {
                if (_changeStatusCommand is null)
                    _changeStatusCommand = new RelayCommand(parameter => ChangeStatus((Product)parameter));

                return _changeStatusCommand;
            }
        }
        private void ChangeStatus(Product parameter)
        {
            if (parameter == null)
                return;

            bool flag = parameter.Status;

            if (parameter.Status)
            {
                var result = MessageBox
                    .Show("¿Está seguro de desactivar el producto '" + parameter.Name +
                    "'?\nTodas las ocurrencias de este producto serán ocultadas de los catalogos donde aparezca",
                    "Confirmar desactivación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) parameter.Status = false;
            }
            else
                parameter.Status = true;

            if (flag != parameter.Status)
                Save(parameter, true);
        }

        private void MessageReceived(object parameter)
        {
            var element = (productModalMessage)parameter;

            if (element.operation is Operation.create or Operation.update)
                Save(element.entity, message.isEdition);
            else
                Delete(element.entity.IdProduct);
        }

        
        private async void Delete(int idProduct)
        {
            await new DeleteCommand<Product>(logic).ExecuteAsync(idProduct);

            await Initialize();
        }

        private async void Save(Product parameter, bool isEdition)
        {
            logic.entity = parameter;
            await new SaveCommand<Product>(logic, canCreate).ExecuteAsync(isEdition);
            messenger.Send(Refresh.stock);
            
            await Initialize();
        }
        public override async Task Initialize()
        {
            dataGridSource = 
                CollectionViewSource.
                GetDefaultView(await logic.GetAll());
            Sort();
        }


        public override void Dispose()
        {
            try
            {
                dataGridSource.Filter = null;
            }
            catch { }

            base.Dispose();
        }
    }
}

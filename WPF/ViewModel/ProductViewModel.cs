using Domain.Entities;
using Domain.Logic;
using Domain.Logic.Base;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        private ICommand openModalCommand { get; }

        private readonly IMessenger messenger;

        private readonly ProductLogic logic;

        public ListingViewModel listingViewModel { get; }


        public ProductViewModel(ILogic _logic, IMessenger _messenger, INavigationService modalNavigation)
        {
            logic = (ProductLogic)_logic;

            listingViewModel = new ListingViewModel(GetProductListing, SortProductListing);

            openModalCommand = new NavigateCommand(modalNavigation);

            addModalCommand = new RelayCommand(o => AddModal());
            editModalCommand = new RelayCommand(parameter => EditModal((Product)parameter));

            messenger = _messenger;
            messenger.Subscribe<ProductModalMessage>(this, MessageReceived);
        }



        public static ProductViewModel LoadViewModel(ILogic parameter, IMessenger messenger, INavigationService navigationService)
        {
            ProductViewModel viewModel = new ProductViewModel(parameter, messenger, navigationService);

            viewModel.listingViewModel.loadCommand.Execute(null);

            return viewModel;
        }


        private void SortProductListing(ICollectionView listing)
        {
            listing.SortDescriptions.Clear();
            listing.SortDescriptions
                .Add(new SortDescription(nameof(Product.IdProduct), ListSortDirection.Descending));
        }

        private async Task<IEnumerable<BaseEntity>> GetProductListing()
        {
            return await logic.GetAll();
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
            if (ListingViewModel.ValidateSearchString(searchText))
            {
                listingViewModel.listing.Filter = Filter;
            }
            else if (searchText.Equals(""))
            {
                listingViewModel.listing.Filter = null;
            }
        }

        private bool Filter(object obj)
        {
            if (obj is Product element)
            {
                return logic.searchLogic(element, searchText);
            }

            return false;
        }

        public ICommand addModalCommand { get; }
        public void AddModal()
        {
            messenger.Send(new ProductMessage(null, false));

            openModalCommand.Execute(-1);
        }


        public ICommand editModalCommand { get; }
        public void EditModal(Product parameter)
        {
            messenger.Send( new ProductMessage(parameter, true));

            openModalCommand.Execute(-1);
        }


        private ICommand _changeStatusCommand;
        public ICommand changeStatusCommand
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
            var element = (ProductModalMessage)parameter;
            var isEdition = element.operation is Operation.update;

            if (element.operation is Operation.create or Operation.update)
                Save(element.entity, isEdition, element.viewModel);
            else
                Delete(element.entity.IdProduct);


            messenger.Send(Refresh.stock);
            listingViewModel.loadCommand.Execute(null);
        }


        private async void Delete(int idProduct)
        {
            await new DeleteCommand(logic).ExecuteAsync(idProduct);
        }

        private void Save(Product parameter, bool isEdition, FormViewModel viewModel = null)
        {
            logic.entity = parameter;
            new SaveCommand(logic, viewModel).Execute(isEdition);
        }

        public override void Dispose()
        {
            try
            {
                if (listingViewModel.listing != null)
                    listingViewModel.listing.Filter = null;
            }
            catch 
            { 
            }

            base.Dispose();
        }
    }
}

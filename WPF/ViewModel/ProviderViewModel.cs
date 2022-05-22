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
    public class ProviderViewModel : ViewModelBase
    {
        private ICommand openModalCommand { get; }

        private readonly IMessenger messenger;

        private readonly ProviderLogic logic;

        public ListingViewModel listingViewModel { get; }


        public ProviderViewModel(ILogic _logic, IMessenger _messenger, INavigationService modalNavigation)
        {
            logic = (ProviderLogic)_logic;

            listingViewModel = new ListingViewModel(GetProviderListing, SortProviderListing);

            openModalCommand = new NavigateCommand(modalNavigation);

            addModalCommand = new RelayCommand(o => AddModal());
            editModalCommand = new RelayCommand(parameter => EditModal((Provider)parameter));

            messenger = _messenger;
            messenger.Subscribe<ProviderModalMessage>(this, MessageReceived);
        }



        public static ProviderViewModel LoadViewModel(ILogic parameter, IMessenger messenger, INavigationService navigationService)
        {
            ProviderViewModel viewModel = new(parameter, messenger, navigationService);

            viewModel.listingViewModel.loadCommand.Execute(null);

            return viewModel;
        }


        private void SortProviderListing(ICollectionView listing)
        {
            listing.SortDescriptions.Clear();
            listing.SortDescriptions
                .Add(new SortDescription(nameof(Provider.IdProvider), ListSortDirection.Descending));
        }

        private async Task<IEnumerable<BaseEntity>> GetProviderListing()
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
                Search();
            }
        }

        private void Search()
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
            if (obj is Provider element)
            {
                return logic.searchLogic(element, searchText);
            }

            return false;
        }

        public ICommand addModalCommand { get; }
        public void AddModal()
        {
            messenger.Send(new ProviderMessage(null, false));

            openModalCommand.Execute(-1);
        }


        public ICommand editModalCommand { get; }
        public void EditModal(Provider parameter)
        {
            messenger.Send(new ProviderMessage(parameter, true));

            openModalCommand.Execute(-1);
        }


        private ICommand _changeStatusCommand;
        public ICommand changeStatusCommand
        {
            get
            {
                if (_changeStatusCommand is null)
                    _changeStatusCommand = new RelayCommand(parameter => ChangeStatus((Provider)parameter));

                return _changeStatusCommand;
            }
        }
        private void ChangeStatus(Provider parameter)
        {
            if (parameter == null)
                return;

            bool flag = parameter.Status;

            if (parameter.Status)
            {
                var result = MessageBox
                    .Show("¿Está seguro de desactivar el proveedor '" + parameter.Name +
                    "'?\nTodas las ocurrencias de este proveedor serán ocultadas de los catalogos donde aparezca",
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
            var element = (ProviderModalMessage)parameter;
            var isEdition = element.operation is Operation.update;

            if (element.operation is Operation.create or Operation.update)
                Save(element.entity, isEdition, element.viewModel);
            else
                Delete(element.entity.IdProvider);
        }


        private async void Delete(int idProvider)
        {
            await new DeleteCommand(logic).ExecuteAsync(idProvider);

            listingViewModel.loadCommand.Execute(null);
        }

        private void Save(Provider parameter, bool isEdition, FormViewModel viewModel = null)
        {
            logic.entity = parameter;
            new SaveCommand(logic, viewModel).Execute(isEdition);

            listingViewModel.loadCommand.Execute(null);
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

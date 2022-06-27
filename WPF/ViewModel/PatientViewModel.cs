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
using WPF.Command.Generic;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class PatientViewModel : ViewModelBase
    {
        private ICommand openModalCommand { get; }

        private readonly IMessenger messenger;

        private readonly ProviderLogic logic;

        public ListingViewModel listingViewModel { get; }


        public PatientViewModel(ILogic _logic, IMessenger _messenger, INavigationService modalNavigation)
        {
            logic = (ProviderLogic)_logic;

            listingViewModel = new ListingViewModel(GetProviderListing, SortProviderListing, PrividerFilter);

            openModalCommand = new NavigateCommand(modalNavigation);

            addModalCommand = new RelayCommand(o => AddModal());
            editModalCommand = new RelayCommand(parameter => EditModal((Provider)parameter));

            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshListing);
            messenger.Subscribe<ProviderModalMessage>(this, MessageReceived);
        }

        public static PatientViewModel LoadViewModel(ILogic parameter, IMessenger messenger, INavigationService navigationService)
        {
            PatientViewModel viewModel = new(parameter, messenger, navigationService);

            viewModel.listingViewModel.loadCommand.Execute(null);

            return viewModel;
        }

        private void SortProviderListing(ICollectionView listing)
        {
            listing.SortDescriptions.Clear();
            listing.SortDescriptions
                .Add(new SortDescription(nameof(Provider.IdProvider), ListSortDirection.Descending));
        }

        private async Task<IEnumerable<BaseEntity>> GetProviderListing() => await logic.GetAll();

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
        private async void ChangeStatus(Provider parameter)
        {
            if (parameter is null)
                return;

            bool flag = parameter.Status;

            if (parameter.Status)
            {
                var result = MessageBox
                    .Show("¿Está seguro de desactivar el proveedor '" + parameter.Name +
                    "'?\nTodas las ocurrencias de este proveedor serán ocultadas de los catalogos donde aparezca",
                    "Confirmar desactivación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                    parameter.Status = false;
            }
            else
                parameter.Status = true;

            if (flag != parameter.Status)
            {
                await Save(parameter, true);
                messenger.Send(Refresh.provider);
            }
        }

        private void RefreshListing(object parameter)
        {
            if (parameter is not Refresh.provider)
                return;

            listingViewModel.loadCommand.Execute(null);
        }

        private async void MessageReceived(object parameter)
        {
            var element = (ProviderModalMessage)parameter;
            var isEdition = element.operation is Operation.update;

            if (element.operation is Operation.create or Operation.update)
                await Save(element.entity, isEdition, element.viewModel);
            else
                await Delete(element.entity.IdProvider);

            messenger.Send(Refresh.provider);
        }

        private async Task Delete(int idProvider)
        {
            await new DeleteCommand(logic).ExecuteAsync(idProvider);
        }

        private async Task Save(Provider parameter, bool isEdition, FormViewModel viewModel = null)
        {
            logic.entity = parameter;
            await new SaveCommand(logic, viewModel).ExecuteAsync(isEdition);
        }

        private bool PrividerFilter(object parameter, string text)
        {
            if (parameter is not Provider)
                return false;

            return ProviderLogic.SearchLogic((Provider)parameter, text);
        }

        public override void Dispose()
        {
            if (listingViewModel.listing is not null)
                listingViewModel.listing.Filter = null;

            base.Dispose();
        }
    }
}

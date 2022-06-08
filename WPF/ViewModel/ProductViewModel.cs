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
    public class ProductViewModel : ViewModelBase
    {
        private ICommand openModalCommand { get; }

        private readonly IMessenger messenger;

        private readonly ProductLogic logic;

        public ListingViewModel listingViewModel { get; }


        public ProductViewModel(ILogic _logic, IMessenger _messenger, INavigationService modalNavigation)
        {
            logic = (ProductLogic)_logic;

            listingViewModel = new ListingViewModel(GetProductListing, SortProductListing, ProductFilter);

            openModalCommand = new NavigateCommand(modalNavigation);

            addModalCommand = new RelayCommand(o => AddModal());
            editModalCommand = new RelayCommand(parameter => EditModal((Product)parameter));

            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshListing);
            messenger.Subscribe<ProductModalMessage>(this, MessageReceived);
        }


        public static ProductViewModel LoadViewModel(ILogic parameter, IMessenger messenger, INavigationService navigationService)
        {
            ProductViewModel viewModel = new(parameter, messenger, navigationService);

            viewModel.listingViewModel.loadCommand.Execute(null);

            return viewModel;
        }

        private void SortProductListing(ICollectionView listing)
        {
            listing.SortDescriptions.Clear();
            listing.SortDescriptions
                .Add(new SortDescription(nameof(Product.IdProduct), ListSortDirection.Descending));
        }

        private async Task<IEnumerable<BaseEntity>> GetProductListing() => await logic.GetAll();

        public ICommand addModalCommand { get; }
        private void AddModal() => OpenModal(new ProductMessage(null, false));

        public ICommand editModalCommand { get; }
        private void EditModal(Product parameter) => OpenModal(new ProductMessage(parameter, true));

        private void OpenModal(ProductMessage message)
        {
            messenger.Send(message);

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
        private async void ChangeStatus(Product parameter)
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

                if (result == MessageBoxResult.Yes) 
                    parameter.Status = false;
            }
            else
                parameter.Status = true;

            if (flag != parameter.Status)
                await Save(parameter, true);
        }

        private void RefreshListing(object parameter)
        {
            if(parameter is Refresh.product)
                listingViewModel.loadCommand.Execute(null);
        }

        private async void MessageReceived(object parameter)
        {
            var element = (ProductModalMessage)parameter;
            var isEdition = element.operation is Operation.update;

            if (element.operation is Operation.create or Operation.update)
                await Save(element.entity, isEdition, element.viewModel);
            else
                await Delete(element.entity.IdProduct);

            NotifyChanges();
        }

        private void NotifyChanges()
        {
            messenger.Send(Refresh.product);
            messenger.Send(Refresh.stock);
        }

        private async Task Delete(int idProduct)
        {
            await new DeleteCommand(logic).ExecuteAsync(idProduct);
        }

        private async Task Save(Product parameter, bool isEdition, FormViewModel viewModel = null)
        {
            logic.entity = parameter;
            await new SaveCommand(logic, viewModel).ExecuteAsync(isEdition);
        }

        private bool ProductFilter(object parameter, string text)
        {
            if (parameter is not Product)
                return false;

            return ProductLogic.SearchLogic((Product)parameter, text);
        }

        public override void Dispose()
        {
            if (listingViewModel.listing != null)
                listingViewModel.listing.Filter = null;

            base.Dispose();
        }
    }
}

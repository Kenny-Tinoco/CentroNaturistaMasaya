using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
using Domain.Logic.Base;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class SaleViewModel : ViewModelBase
    {
        public ICommand openFormCommand { get; }

        private readonly IMessenger messenger;

        private readonly SaleLogic logic;

        public ListingViewModel listingViewModel { get; }


        public SaleViewModel(ILogic _logic, IMessenger _messenger, INavigationService formNavigation)
        {
            logic = (SaleLogic)_logic;

            listingViewModel = new ListingViewModel(GetSaleListing, SortSaleListing, SaleViewFilter);

            openFormCommand = new NavigateCommand(formNavigation);

            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshSalesChanges);
            selectedItem = null;
        }


        public static SaleViewModel LoadViewModel(ILogic parameter, IMessenger messenger, INavigationService navigationService)
        {
            SaleViewModel viewModel = new(parameter, messenger, navigationService);

            viewModel.listingViewModel.loadCommand.Execute(null);

            return viewModel;
        }

        private void SortSaleListing(ICollectionView listing)
        {
            listing.SortDescriptions.Clear();
            listing.SortDescriptions
                .Add(new SortDescription(nameof(Sell.IdSell), ListSortDirection.Descending));
        }

        private async Task<IEnumerable<BaseEntity>> GetSaleListing() => 
            await logic.viewsCollections.SellViewCatalog();

        private void RefreshSalesChanges(object parameter)
        {
            if ((Refresh)parameter is not Refresh.sale)
                return;

            listingViewModel.loadCommand.Execute(null);
        }

        private SellView _selectedItem;
        public SellView selectedItem 
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;

                if (_selectedItem is not null)
                    GetDetails();

                OnPropertyChanged(nameof(selectedItem));
                OnPropertyChanged(nameof(anItemIsSelected));
            }
        }

        private async void GetDetails()
        {
            saleDetails = await logic.GetDetails(_selectedItem.IdSell);
        }

        public bool anItemIsSelected => selectedItem is not null;

        private IEnumerable<SaleDetailView> _saleDetails;
        public IEnumerable<SaleDetailView> saleDetails
        {
            get => _saleDetails;
            set
            {
                _saleDetails = value;
                OnPropertyChanged(nameof(saleDetails));
            }
        }

        public ICommand closeDetails => new RelayCommand(o => 
        { 
            selectedItem = null; 
        });

        private bool SaleViewFilter(object parameter, string text)
        {
            if (parameter is not SellView)
                return false;

            return SaleLogic.SearchLogic((SellView)parameter, text);
        }

        public override void Dispose()
        {
            if (listingViewModel.listing is not null)
                listingViewModel.listing.Filter = null;

            base.Dispose();
        }
    }
}

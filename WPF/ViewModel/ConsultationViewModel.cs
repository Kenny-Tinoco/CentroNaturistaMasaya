using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
using Domain.Logic.Base;
using Domain.Utilities;
using MVVMGenericStructure.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;
using WPF.ViewModel.Utilities;

namespace WPF.ViewModel
{
    public class ConsultationViewModel : ViewModelBase
    {
        private readonly PurchaseLogic logic;

        public ListingViewModel listingViewModel { get; }


        public ConsultationViewModel(ILogic _logic, IMessenger _messenger)
        {
            logic = (PurchaseLogic)_logic;

            listingViewModel = new ListingViewModel(GetPurchaseListing, SortPurchaseListing, PurchaseViewFilter);

            _messenger.Subscribe<Refresh>(this, RefreshListings);
            selectedItem = null;
        }


        public static ConsultationViewModel LoadViewModel(ILogic parameter, IMessenger messenger)
        {
            ConsultationViewModel viewModel = new(parameter, messenger);

            viewModel.Load();

            return viewModel;
        }

        public void Load()
        {
            RefreshListings(Refresh.provider);

            RefreshListings(Refresh.purchase);
        }

        private async Task LoadProviders()
        {
            providerListing = new();
            var list = await logic.GetProviders();

            foreach (var (name, idProvider) in list)
                providerListing.Add(new { name = name, idProvider = idProvider });
        }

        private void SortPurchaseListing(ICollectionView listing)
        {
            listing.SortDescriptions.Clear();
            listing.SortDescriptions
                .Add(new SortDescription(nameof(Supply.Date), ListSortDirection.Descending));
        }

        private async Task<IEnumerable<BaseEntity>> GetPurchaseListing() =>
            await logic.viewsCollections.SupplyViewCatalog
            (
                periodSelected is null ? Periods.ThisMonth : periodSelected.period,
                (int)(providerSelected is null ? -1 : providerSelected.idProvider)
            );

        private async void RefreshListings(object parameter)
        {
            if (parameter is Refresh.purchase)
            {
                listingViewModel.loadCommand.Execute(null);
            }
            else if (parameter is Refresh.provider)
            {
                await LoadProviders();
            }
        }

        private SupplyView _selectedItem;
        public SupplyView selectedItem
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

        private async void GetDetails() => supplyDetails = await logic.GetDetails(_selectedItem.IdSupply);

        public bool anItemIsSelected => selectedItem is not null;

        private IEnumerable<SupplyDetailView> _supplyDetails;
        public IEnumerable<SupplyDetailView> supplyDetails
        {
            get => _supplyDetails;
            set
            {
                _supplyDetails = value;
                OnPropertyChanged(nameof(supplyDetails));
            }
        }

        private List<dynamic> _providerListing;
        public List<dynamic> providerListing
        {
            get => _providerListing;
            set
            {
                _providerListing = value;
                OnPropertyChanged(nameof(providerListing));

                OnPropertyChanged(nameof(providerSelected));
            }
        }

        private dynamic _providerSelected;
        public dynamic providerSelected
        {
            get => _providerSelected;
            set
            {
                _providerSelected = value;
                OnPropertyChanged(nameof(providerSelected));

                RefreshListings(Refresh.purchase);
            }
        }

        private List<Period> _periodListing;
        public List<Period> periodListing
        {
            get
            {
                if (_periodListing is null)
                    _periodListing = new List<Period>
                    {
                        new(Periods.ThisMonth, "Este mes"),
                        new(Periods.LastSixMonths, "Últimos seis meses"),
                        new(Periods.ThisYear, "Este año"),
                        new(Periods.AllTime, "Todo el tiempo")
                    };

                return _periodListing;
            }
        }

        private Period _periodSelected;
        public Period periodSelected
        {
            get
            {
                if (_periodSelected is null)
                    _periodSelected = periodListing[0];

                return _periodSelected;
            }
            set
            {
                _periodSelected = value;
                OnPropertyChanged(nameof(periodSelected));

                RefreshListings(Refresh.purchase);
            }
        }


        public ICommand closeDetails => new RelayCommand(o =>
        {
            selectedItem = null;
        });

        private bool PurchaseViewFilter(object parameter, string text)
        {
            if (parameter is not SupplyView)
                return false;

            return PurchaseLogic.SearchLogic((SupplyView)parameter, text);
        }

        public override void Dispose()
        {
            if (listingViewModel.listing is not null)
                listingViewModel.listing.Filter = null;

            base.Dispose();
        }
    }
}

using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class StockViewerViewModel : ListingViewModel
    {
        private readonly StockViewerLogic logic;
        private readonly IMessenger messenger;

        public StockViewerViewModel(StockViewerLogic _logic, IMessenger _messenger) : base()
        {
            logic = _logic;

            getListing = new(GetListings);
            sortListing = new(SortStockView);
            searchViewModel = new(StockViewFilter);

            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshListing);
        }

        public static StockViewerViewModel LoadViewModel(StockViewerLogic _logic, IMessenger _messenger)
        {
            StockViewerViewModel viewModel = new(_logic, _messenger);

            viewModel.loadCommand.Execute(null);

            return viewModel;
        }

        public ICommand sendItemCommand => new RelayCommand(parameter =>
        {
            if (parameter is null)
                return;

            messenger.Send(new StockViewerMessage((StockView)parameter));
        });

        public bool hasListing => listing is not null;

        private ObservableCollection<Presentation> _presentationListing = new();
        public ObservableCollection<Presentation> presentationListing
        {
            get => _presentationListing;
            set
            {
                _presentationListing = value;
                OnPropertyChanged(nameof(presentationListing));
            }
        }

        private Presentation _presentationSelected;
        public Presentation presentationSelected
        {
            get => _presentationSelected;
            set
            {
                _presentationSelected = value;

                if (_presentationSelected is not null)
                    text = _presentationSelected.Name;

                OnPropertyChanged(nameof(presentationSelected));
            }
        }

        public override ICollectionView listing
        {
            get => base.listing;
            set
            {
                base.listing = value;
                OnPropertyChanged(nameof(hasListing));
            }
        }

        public string searchText
        {
            get
            {
                if (string.IsNullOrEmpty(text) && presentationSelected is not null)
                    presentationSelected = null;

                return text;
            }
            set => text = value;
        }

        private bool StockViewFilter(object parameter, string text)
        {
            if (parameter is not StockView)
                return false;

            return StockLogic.SearchLogic((StockView)parameter, text);
        }

        private void SortStockView(ICollectionView listing)
        {
            listing.SortDescriptions
                .Clear();

            listing.SortDescriptions
                .Add(new SortDescription(nameof(StockView.Name), ListSortDirection.Ascending));
        }

        private async Task<IEnumerable<BaseEntity>> GetListings()
        {
            await GetPresentationListing();
            return await logic.GetStockListing();
        }

        private async Task GetPresentationListing()
        {
            var _listing = await logic.GetPresentationListing();

            presentationListing.Clear();
            foreach (var item in _listing)
                presentationListing.Add(item);
        }

        private void RefreshListing(object parameter)
        {
            if (((Refresh)parameter) is not Refresh.stock)
                return;

            loadCommand.Execute(null);
        }

        public override void Dispose()
        {
            messenger.Unsubscribe<Refresh>(this);
            base.Dispose();
        }
    }
}

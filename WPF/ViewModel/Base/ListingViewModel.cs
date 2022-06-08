using Domain.Entities;
using MVVMGenericStructure.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Command.Generic;

namespace WPF.ViewModel.Base
{
    public class ListingViewModel : ViewModelBase
    {
        public ICommand loadCommand { get; }

        protected GetListing getListing;
        
        protected SortListing sortListing;

        private MessageViewModel _errorMessage { get; }

        protected SearchBarViewModel searchViewModel;

        protected ListingViewModel()
        {
            _errorMessage = new MessageViewModel();

            loadCommand = new LoadCommand(this);
        }

        public ListingViewModel(GetListing _getListing, SortListing _sortListing = null, FilterLogic _filter = null) : this()
        {
            getListing = _getListing;

            sortListing = _sortListing;

            searchViewModel = new(_filter);
        }

        public async Task Load()
        {
            try
            {
                await Initialize();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task Initialize()
        {
            var resultListing = await getListing();

            listing = CollectionViewSource.GetDefaultView(resultListing);

            searchViewModel.listing = listing;
        }

        private bool _isLoading;
        public bool isLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(isLoading));
                OnPropertyChanged(nameof(isListingVisible));
            }
        }

        private ICollectionView _listing;
        public virtual ICollectionView listing
        {
            get
            {
                if (_listing != null && sortListing != null)
                    sortListing(_listing);

                return _listing;
            }
            set
            {
                _listing = value;
                OnPropertyChanged(nameof(listing));
            }
        }

        public string errorMessage
        {
            get => _errorMessage.message;
            set
            {
                _errorMessage.message = value;
                OnPropertyChanged(nameof(errorMessage));
                OnPropertyChanged(nameof(hasErrorMessage));
                OnPropertyChanged(nameof(isListingVisible));
            }
        }

        public string text
        {
            get => searchViewModel.text;
            set => searchViewModel.text = value;
        }

        public bool hasErrorMessage => _errorMessage.hasMessage;

        public bool isListingVisible => !hasErrorMessage && !isLoading;

    }

    public delegate void SortListing(ICollectionView listing);

    public delegate Task<IEnumerable<BaseEntity>> GetListing();
}

using Domain.Entities;
using MVVMGenericStructure.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Command.CRUD;

namespace WPF.ViewModel.Base
{
    public class ListingViewModel : ViewModelBase
    {
        public ICommand loadCommand{ get; }

        public GetListing getListing;
        public SortListing sortListing;

        private MessageViewModel _errorMessage { get; }


        public ListingViewModel(GetListing _getListing, SortListing _sortListing = null)
        {
            getListing = _getListing;
            sortListing = _sortListing;

            _errorMessage = new MessageViewModel();

            loadCommand = new LoadCommand(this);
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
        public ICollectionView listing
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
            get =>_errorMessage.message;
            set
            {
                _errorMessage.message = value;
                OnPropertyChanged(nameof(errorMessage));
                OnPropertyChanged(nameof(hasErrorMessage));
                OnPropertyChanged(nameof(isListingVisible));
            }
        }
        
        public bool hasErrorMessage => _errorMessage.hasMessage;

        public bool isListingVisible => !hasErrorMessage && !isLoading;

        public static bool ValidateSearchString(string parameter)
        {
            return
                !parameter.Trim().Equals("Búscar") &&
                !parameter.Trim().Equals("");
        }

    }

    public delegate void SortListing(ICollectionView listing);

    public delegate Task<IEnumerable<BaseEntity>> GetListing();
}

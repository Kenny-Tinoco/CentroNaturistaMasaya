using System.ComponentModel;

namespace WPF.ViewModel.Base
{
    public class SearchBarViewModel
    {
        public ICollectionView listing { get; set; }
        private readonly FilterLogic Logic;
        private string _searchText;
        
        public SearchBarViewModel()
        {
        }

        public SearchBarViewModel(ICollectionView _listing, FilterLogic _logic) : this(_logic)
        {
            listing = _listing;
        }

        public SearchBarViewModel(FilterLogic _logic)
        {
            if(_logic is not null)
                Logic = _logic;
        }

        public string text
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
            if (listing is null)
                return;

            if (text.Equals(string.Empty))
            {
                listing.Filter = null;
                return;
            }

            listing.Filter = Filter;
        }

        private bool Filter(object parameter) => Logic(parameter, _searchText.Trim());
    }

    public delegate bool FilterLogic(object parameter, string text);
}

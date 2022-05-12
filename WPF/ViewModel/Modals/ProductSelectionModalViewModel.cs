using Domain.Entities;
using MVVMGenericStructure.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class ProductSelectionModalViewModel : ModalViewModel
    {
        public string titleBar { get; }

        public IMessenger messenger;

        public ProductSelectionModalViewModel(IMessenger _messenger, INavigationService closeModal) : base(closeModal)
        {
            titleBar = "Selecionar un producto";

            messenger = _messenger;
            messenger.Subscribe<IEnumerable<Product>>(this, CatalogueReceived);
            GoCommand = new RelayCommand(parameter => Go((Product)parameter));
        }

        private void CatalogueReceived(object parameter)
        {
            dataGridSource = CollectionViewSource.GetDefaultView((IEnumerable<Product>)parameter);
            Sort();
        }

        public ICommand GoCommand { get; }

        public void Go(Product parameter)
        {
            messenger.Send(parameter);
            ExitCommand.Execute(-1);
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

        public void Search()
        {
            if (dataGridSource is null)
                return;

            if (ValidateSearchString(searchText))
            {
                dataGridSource.Filter = Filter;
            }
            else if (searchText.Equals(""))
            {
                dataGridSource.Filter = null;
            }
        }

        private bool ValidateSearchString(string parameter) => !parameter.Trim().Equals("Búscar") && !parameter.Trim().Equals("");

        private bool Filter(object parameter)
        {
            if (parameter is Product element)
            {
                return SearchLogic(element, searchText);
            }

            return false;
        }
        public static bool SearchLogic(Product element, string parameter) =>
            element.IdProduct.ToString().Contains(parameter.Trim()) ||
            element.Name.ToLower().StartsWith(parameter.Trim().ToLower());


        public ICollectionView dataGridSource
        {
            get;
            private set;
        }
        private void Sort()
        {
            dataGridSource.SortDescriptions
                .Clear();
            dataGridSource.SortDescriptions
                .Add(new SortDescription(nameof(Product.IdProduct), ListSortDirection.Descending));
        }


        public override void Dispose()
        {
            searchText = "";
            base.Dispose();
        }

    }
}

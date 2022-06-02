using Domain.Entities;
using Domain.Logic;
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

        private SearchBarViewModel searchViewModel = new();

        public ProductSelectionModalViewModel(IMessenger _messenger, INavigationService closeModal) : base(closeModal)
        {
            titleBar = "Selecionar un producto";

            messenger = _messenger;
            messenger.Subscribe<IEnumerable<Product>>(this, CatalogueReceived);
            goCommand = new RelayCommand(parameter => Go((Product)parameter));
        }

        private void CatalogueReceived(object parameter)
        {
            listing = CollectionViewSource.GetDefaultView((IEnumerable<Product>)parameter);
            Sort();

            searchViewModel = new(listing, ProductFilter);
        }

        public ICommand goCommand { get; }

        public void Go(Product parameter)
        {
            messenger.Send(parameter);
            exitCommand.Execute(-1);
        }

        public string text
        {
            get => searchViewModel.text;
            set => searchViewModel.text = value;
        }

        private bool ProductFilter(object parameter, string text)
        {
            if (parameter is not Product)
                return false;

            return ProductLogic.SearchLogic((Product)parameter, text);
        }

        public ICollectionView listing
        {
            get;
            private set;
        }

        private void Sort()
        {
            listing.SortDescriptions
                .Clear();
            listing.SortDescriptions
                .Add(new SortDescription(nameof(Product.IdProduct), ListSortDirection.Descending));
        }

        public override void Dispose()
        {
            listing.Filter = null;

            base.Dispose();
        }

    }
}

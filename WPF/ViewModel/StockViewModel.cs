using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
using Domain.Logic.Base;
using Domain.Utilities;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class StockViewModel : ViewModelBase
    {
        private ICommand openFormCommand { get; }

        private Views viewType;

        private readonly StockLogic logic;

        private readonly IMessenger messenger;

        public ListingViewModel listingViewModel { get; }



        public StockViewModel(ILogic _logic, IMessenger _messenger, INavigationService formNavigationService)
        {
            logic = (StockLogic)_logic;

            listingViewModel = new ListingViewModel(GetStockViewListing, SortStockViewListing);

            openFormCommand = new NavigateCommand(formNavigationService);

            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshStockChanges);

            viewType = Views.OnlyActive;
        }


        public static StockViewModel LoadViewModel(ILogic _logic, IMessenger _messenger, INavigationService formNavigationService)
        {
            StockViewModel viewModel = new(_logic, _messenger, formNavigationService);

            viewModel.listingViewModel.loadCommand.Execute(null);

            return viewModel;
        }



        private async Task<IEnumerable<BaseEntity>> GetStockViewListing()
        {
            return await logic.viewsCollections.StockViewCatalog(viewType);
        }

        private void SortStockViewListing(ICollectionView listing)
        {
            listing.SortDescriptions
                .Clear();

            listing.SortDescriptions
                .Add(new SortDescription(nameof(StockView.EntryDate), ListSortDirection.Descending));
        }


        private ICommand _editCommand;
        public ICommand editCommand
        {
            get
            {
                if (_editCommand is null)
                    _editCommand = new RelayCommand(parameter => Edit((int)parameter));

                return _editCommand;
            }
        }

        private void Edit(int idStock)
        {
            var hasChangeableState = logic.hasChangeableState(idStock);

            if (!hasChangeableState)
            {
                return;
            }

            var entity = logic.getStock(idStock);
            messenger.Send(new StockMessage(entity, true));

            openFormCommand.Execute(-1);
        }

        private ICommand _addCommand;
        public ICommand addCommand
        {
            get
            {
                if (_addCommand is null)
                    _addCommand = new RelayCommand(o => Add());

                return _addCommand;
            }
        }
        private void Add()
        {
            messenger.Send(new StockMessage(null, false));

            openFormCommand.Execute(-1);
        }


        private ICommand _deleteCommand;
        public ICommand deleteCommand
        {
            get
            {
                if (_deleteCommand is null)
                    _deleteCommand = new RelayCommand(parameter => Delete((int)parameter));

                return _deleteCommand;
            }
        }
        private async void Delete(int idStock)
        {
            var result = MessageBox
                .Show("¿Está seguro de eliminar esta existencia?\n" +
                      "Se desencadenará una eliminación en cascada de todos los registros que tengan alguna relación con esta existencia.\n\n" +
                      "Antes de eliminarla considere la opción de deshabilitar, dicha opción oculta todas las ocurrencias de la misma sin hacer eliminaciones.",
                      "Confirmar Eliminación",
                       MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
                return;

            await new DeleteCommand(logic).ExecuteAsync(idStock);

            listingViewModel.loadCommand.Execute(null);
        }


        private string _searchText;
        public string searchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                Search();
            }
        }

        private void Search()
        {
            if (ListingViewModel.ValidateSearchString(searchText))
            {
                listingViewModel.listing.Filter = Filter;
            }
            else if (searchText.Equals(""))
            {
                listingViewModel.listing.Filter = null;
            }
        }

        private bool Filter(object parameter)
        {
            if (parameter is StockView element)
            {
                return logic.searchLogic(element, searchText);
            }

            return false;
        }


        private bool _groupPresentation;
        public bool group
        {
            get => _groupPresentation;
            set
            {
                _groupPresentation = value;
                GroupSortForPresentation(_groupPresentation);
                OnPropertyChanged(nameof(group));
            }
        }
        private void GroupSortForPresentation(bool parameter)
        {
            Clear();
            if (parameter)
            {
                _groupAll = false;
                OnPropertyChanged(nameof(groupAll));

                listingViewModel.listing
                    .GroupDescriptions
                    .Add(new PropertyGroupDescription(nameof(StockView.Presentation)));
            }
            else
                SortStockViewListing(listingViewModel.listing);
        }
        private void Clear()
        {
            listingViewModel.listing.GroupDescriptions.Clear();
        }



        private bool _viewOnlyInactives;
        public bool viewOnlyInactives
        {
            get => _viewOnlyInactives;
            set
            {
                _viewOnlyInactives = value;
                ViewOnlyInactives(_viewOnlyInactives);
                OnPropertyChanged(nameof(viewOnlyInactives));
            }
        }
        private void ViewOnlyInactives(bool parameter)
        {
            _viewAll = false;
            _groupAll = false;
            _groupPresentation = false;
            OnPropertyChanged(nameof(viewAll));
            OnPropertyChanged(nameof(groupAll));
            OnPropertyChanged(nameof(group));
            if (parameter)
            {
                viewType = Views.OnlyInactive;
            }
            else
            {
                viewType = Views.OnlyActive;
            }
            listingViewModel.loadCommand.Execute(null);
        }


        private bool _viewAll;
        public bool viewAll
        {
            get => _viewAll;
            set
            {
                _viewAll = value;
                ViewAll(_viewAll);
                OnPropertyChanged(nameof(viewAll));
            }
        }
        private void ViewAll(bool parameter)
        {
            _groupPresentation = false;
            _viewOnlyInactives = false;
            OnPropertyChanged(nameof(group));
            OnPropertyChanged(nameof(viewOnlyInactives));
            if (parameter)
            {
                viewType = Views.All;
            }
            else
            {
                _groupAll = false;
                OnPropertyChanged(nameof(groupAll));
                viewType = Views.OnlyActive;
            }
            listingViewModel.loadCommand.Execute(null);
        }


        private bool _groupAll;
        public bool groupAll
        {
            get => _groupAll;
            set
            {
                _groupAll = value;
                GroupAll(_groupAll);
                OnPropertyChanged(nameof(groupAll));
            }
        }
        private void GroupAll(bool parameter)
        {
            Clear();
            if (parameter)
            {
                _groupPresentation = false;
                OnPropertyChanged(nameof(group));

                listingViewModel.listing
                    .GroupDescriptions
                    .Add(new PropertyGroupDescription(nameof(StockView.Status)));
            }
        }

        private void RefreshStockChanges(object parameter)
        {
            if ((Refresh)parameter is not Refresh.stock)
                return;

            listingViewModel.loadCommand.Execute(null);
        }

        public override void Dispose()
        {
            if (listingViewModel.listing != null)
                listingViewModel.listing.Filter = null;

            base.Dispose();
        }
    }
}
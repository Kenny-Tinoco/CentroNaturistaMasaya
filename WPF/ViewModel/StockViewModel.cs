using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
using Domain.Utilities;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
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

namespace WPF.ViewModel
{
    public class StockViewModel : ViewModelGeneric<Stock>
    {
        private ICommand OpenFormCommand { get; }

        private readonly IMessenger messenger;
        public IEnumerable<StockView> StockViewCatalog { get; set; }


        public StockViewModel(BaseLogic<Stock> parameter, IMessenger _messenger, INavigationService FormNavigationService) : base((StockLogic)parameter)
        {
            OpenFormCommand = new NavigateCommand(FormNavigationService);

            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshStockChanges);
        }


        public static StockViewModel LoadViewModel(BaseLogic<Stock> parameter, IMessenger _messenger, INavigationService FormNavigationService)
        {
            StockViewModel viewModel = new StockViewModel(parameter, _messenger, FormNavigationService);

            viewModel.loadCatalogueCommand.Execute(null);

            return viewModel;
        }

        public async override Task Initialize()
        {
            if(viewOnlyInactives == true)
                await GetCatalogue(Views.OnlyInactive);
            else if(viewAll == true)
                await GetCatalogue(Views.All);
            else
                await GetCatalogue(Views.OnlyActive);
        }

        private async Task GetCatalogue(Views type)
        {
            StockViewCatalog = await ((StockLogic)logic).viewsCollections.StockViewCatalog(type);
            dataGridSource = CollectionViewSource.GetDefaultView(StockViewCatalog);
            Sort();
        }

        private ICommand _editCommand;
        public ICommand EditCommand
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
            var hasChangeableState = ((StockLogic)logic).hasChangeableState(idStock);

            if (!hasChangeableState)
            {
                return;
            }

            var entity = ((StockLogic)logic).getStock(idStock);
            messenger.Send(new StockMessage(entity, true));

            OpenFormCommand.Execute(-1);
        }

        private ICommand _addCommand;
        public ICommand AddCommand
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

            OpenFormCommand.Execute(-1);
        }


        private ICommand _deleteCommand;
        public ICommand DeleteCommand
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
            
            await new DeleteCommand<Stock>(logic).ExecuteAsync(idStock);
            await Initialize();
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
            if (ValidateSearchString(searchText))
            {
                dataGridSource.Filter = Filter;
            }
            else if (searchText.Equals(""))
            {
                dataGridSource.Filter = null;
            }
        }

        private bool Filter(object parameter)
        {
            if (parameter is StockView element)
            {
                return ((StockLogic)logic).searchLogic(element, searchText);
            }

            return false;
        }


        private bool _groupSortPresentation;
        public bool groupSort
        {
            get => _groupSortPresentation;
            set
            {
                _groupSortPresentation = value;
                GroupSortForPresentation(_groupSortPresentation);
                OnPropertyChanged(nameof(groupSort));
            }
        }
        private void GroupSortForPresentation(bool parameter)
        {
            Clear();
            if (parameter)
            {
                _groupAll = false;
                OnPropertyChanged(nameof(groupAll));

                _dataGridSource
                    .GroupDescriptions
                    .Add(new PropertyGroupDescription(nameof(StockView.Presentation)));
                _dataGridSource
                     .SortDescriptions
                     .Add(new SortDescription(nameof(StockView.Presentation), ListSortDirection.Ascending));
            }
            else
                Sort();
        }
        private void Clear()
        {
            _dataGridSource.GroupDescriptions.Clear();
            _dataGridSource.SortDescriptions.Clear();
        }

        private void Sort()
        {
            _dataGridSource.SortDescriptions
                .Clear();
            _dataGridSource.SortDescriptions
                .Add(new SortDescription(nameof(StockView.EntryDate), ListSortDirection.Descending));
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
        private async void ViewOnlyInactives(bool parameter)
        {
            _viewAll = false;
            _groupAll = false;
            _groupSortPresentation = false;
            OnPropertyChanged(nameof(viewAll));
            OnPropertyChanged(nameof(groupAll));
            OnPropertyChanged(nameof(groupSort));
            if (parameter)
            {
                await GetCatalogue(Views.OnlyInactive);
            }
            else
            {
                await GetCatalogue(Views.OnlyActive);
            }
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
        private async void ViewAll(bool parameter)
        {
            _groupSortPresentation = false;
            _viewOnlyInactives = false;
            OnPropertyChanged(nameof(groupSort));
            OnPropertyChanged(nameof(viewOnlyInactives));
            if (parameter)
            {
                await GetCatalogue(Views.All);
            }
            else
            {
                _groupAll = false;
                OnPropertyChanged(nameof(groupAll));
                await GetCatalogue(Views.OnlyActive);
            }
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
                _groupSortPresentation = false;
                OnPropertyChanged(nameof(groupSort));

                _dataGridSource
                    .GroupDescriptions
                    .Add(new PropertyGroupDescription(nameof(StockView.Status)));
            }
        }



        private ICollectionView _dataGridSource;
        public ICollectionView dataGridSource
        {
            get
            {
                if (_dataGridSource == null)
                {
                    _dataGridSource = CollectionViewSource.GetDefaultView(StockViewCatalog);
                }

                Sort();
                return _dataGridSource;
            }
            set
            {
                _dataGridSource = value;
                OnPropertyChanged(nameof(dataGridSource));
            }
        }


        private async void RefreshStockChanges(object parameter)
        {
            if( (Refresh)parameter is not Refresh.stock )
                return;

            await Initialize();
        }


        public override void Dispose()
        {
            try
            {
                dataGridSource.Filter = null;
                Clear();
            }
            catch { }

            base.Dispose();
        }
    }
}
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
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
using WPF.Stores;

namespace WPF.ViewModel
{
    public class StockViewModel : ViewModelGeneric<Stock>
    {
        private ICommand OpenFormCommand { get; }

        private readonly EntityStore entityStore;
        public IEnumerable<StockView> StockViewCatalog { get; set; }


        public StockViewModel(BaseLogic<Stock> parameter, EntityStore _entityStore, INavigationService FormNavigationService) : base((StockLogic)parameter)
        {
            OpenFormCommand = new NavigateCommand(FormNavigationService);

            entityStore = _entityStore;
            entityStore.RefreshStock += RefreshStockChanges;
        }


        public static StockViewModel LoadViewModel(BaseLogic<Stock> parameter, EntityStore _entityStore, INavigationService addStockNavigationService)
        {
            StockViewModel viewModel = new StockViewModel(parameter, _entityStore, addStockNavigationService);

            viewModel.LoadCatalogueCommand.Execute(null);

            return viewModel;
        }

        public override async Task Initialize()
        {
            StockViewCatalog = await ((StockLogic)logic).viewsCollections.StockViewCatalog();
            dataGridSource = CollectionViewSource.GetDefaultView(StockViewCatalog);
            sort(false);
        }


        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (_editCommand is null)
                    _editCommand = new RelayCommand(parameter => edit((StockView)parameter));

                return _editCommand;
            }
        }
        private void edit(StockView parameter)
        {
            entityStore.entity = ((StockLogic)logic).getStock(parameter.IdStock);
            entityStore.isEdition = true;
            OpenFormCommand.Execute(-1);
        }


        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand is null)
                    _addCommand = new RelayCommand(parameter => add());

                return _addCommand;
            }
        }
        private void add()
        {
            entityStore.entity = null;
            entityStore.isEdition = false;
            OpenFormCommand.Execute(-1);
        }


        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand is null)
                    _deleteCommand = new RelayCommand(parameter => delete((StockView)parameter));

                return _deleteCommand;
            }
        }
        private async void delete(StockView parameter)
        {
            var element = await logic.getById(parameter.IdStock);
            var result = MessageBox
                .Show("¿Está seguro de eliminar esta existencia?\n" +
                      "Se desencadenará una eliminación en cascada de todos los registros que tengan alguna relación con esta existencia.\n\n" +
                      "Antes de eliminarla considere la opción de deshabilitar esta existencia, dicha opción oculta todas las ocurrencias de " +
                      "la sin hacer eliminaciones.",
                      "Confirmar Eliminación",
                       MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                await new DeleteCommand<Stock>(logic).ExecuteAsync(element);

            await Initialize();
        }


        private string _searchText;
        public string searchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                search();
            }
        }

        public void search()
        {
            if (validateSearchString(searchText))
            {
                dataGridSource.Filter = filter;
            }
            else if (searchText.Equals(""))
            {
                dataGridSource.Filter = null;
            }
        }

        private bool filter(object parameter)
        {
            if (parameter is StockView element)
            {
                return ((StockLogic)logic).searchLogic(element, searchText);
            }

            return false;
        }


        private ICommand _sortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_sortCommand is null)
                    _sortCommand = new RelayCommand(parameter => sort((bool)parameter));

                return _sortCommand;
            }
        }
        private void sort(bool parameter)
        {
            _dataGridSource.SortDescriptions.Clear();
            if (parameter)
            {
                _dataGridSource
                     .SortDescriptions
                    .Add(new SortDescription(nameof(StockView.IdStock), ListSortDirection.Ascending));
            }
            else
            {
                _dataGridSource
                     .SortDescriptions
                     .Add(new SortDescription(nameof(StockView.IdStock), ListSortDirection.Descending));
            }
        }


        private ICommand _groupSortCommand;
        public ICommand GroupCommand
        {
            get
            {
                if (_groupSortCommand is null)
                    _groupSortCommand = new RelayCommand(parameter => groupSort((bool)parameter));

                return _groupSortCommand;
            }
        }
        private void groupSort(bool parameter)
        {
            _dataGridSource.GroupDescriptions.Clear();
            _dataGridSource.SortDescriptions.Clear();
            if (parameter)
            {
                _dataGridSource
                    .GroupDescriptions
                    .Add(new PropertyGroupDescription(nameof(StockView.Presentation)));
                _dataGridSource
                     .SortDescriptions
                     .Add(new SortDescription(nameof(StockView.Presentation), ListSortDirection.Ascending));
            }
            else
                sort(false);
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
                sort(false);
                return _dataGridSource;
            }
            set
            {
                _dataGridSource = value;
                OnPropertyChanged(nameof(dataGridSource));
            }
        }


        private async void RefreshStockChanges()
        {
            await Initialize();
        }


        public override void Dispose()
        {
            dataGridSource.Filter = null;
            dataGridSource.SortDescriptions.Clear();
            dataGridSource.GroupDescriptions.Clear();

            base.Dispose();
        }
    }
}
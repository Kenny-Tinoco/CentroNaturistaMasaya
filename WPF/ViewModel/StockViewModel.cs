using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Stores;

namespace WPF.ViewModel
{
    public class StockViewModel : ViewModelGeneric<Stock>
    {

        public ICommand addCommand { get; }
        public ICommand saveCommand { get; }
        public ICommand deleteCommand { get; }

        private EntityStore entityStore;
        public IEnumerable<StockView> StockViewCatalog { get; set; }

        public INavigationService navigationService;


        public StockViewModel(BaseLogic<Stock> parameter, EntityStore _entityStore, INavigationService addStockNavigationService) : base((StockLogic)parameter)
        {
            addCommand = new NavigateCommand(addStockNavigationService);
            saveCommand = new SaveCommand<Stock>(logic, canCreate);
            deleteCommand = new DeleteCommand<Stock>(logic);

            entityStore = _entityStore;
            entityStore.Refresh += RefreshChanges;
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
            DataGridSource.Source = StockViewCatalog;
            dataGridSource = DataGridSource.View;
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
                search();
            }
        }

        public void search()
        {
            if (validateSearchString(searchText))
            {
                DataGridSource.Filter += new FilterEventHandler(DataGridSource_Filter);
            }
            else if (searchText.Equals(""))
            {
                DataGridSource.Filter += null;
            }
        }

        private void DataGridSource_Filter(object sender, FilterEventArgs e)
        {
            StockView element = e.Item as StockView;
            if (element != null)
            {
                if (((StockLogic)logic).searchLogic(element, searchText))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }


        private ICollectionView _dataGridSourceView;
        public ICollectionView dataGridSource
        {
            get
            {
                return _dataGridSourceView;
            }
            set
            {
                _dataGridSourceView = value;
                OnPropertyChanged(nameof(dataGridSource));
            }
        }

        private CollectionViewSource _dataGridSource;
        private CollectionViewSource DataGridSource
        {
            get
            {
                if (_dataGridSource == null)
                {
                    _dataGridSource = new CollectionViewSource();
                    _dataGridSource.Source = catalogue;
                }
                return _dataGridSource;
            }
            set
            {
                _dataGridSource = value;
            }
        }

        private async void RefreshChanges()
        {
            await Initialize();
        }

    }
}
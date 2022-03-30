using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MasayaNaturistCenter.Logic;
using MasayaNaturistCenter.Services;
using MasayaNaturistCenter.Stores;
using MasayaNaturistCenter.Command;
using MasayaNaturistCenter.Model.DTO;

namespace MasayaNaturistCenter.ViewModel
{
    public class StockViewModel : ViewModelBase
    {
        public ILogic stockLogic;
        private string _searchText;
        public INavigationService navigationService;
        private CollectionViewSource _dataGridSource;
        private ObservableCollection<StockViewDTO> _stockList;
        
        public StockDTO currentStock { get; set; }

        public ICommand addCommand { get; }
        public ICommand saveCommand { get; }
        public ICommand deleteCommand { get; }


        public StockViewModel
        (
            ILogic parameter, 
            ModalNavigationStore navigationStore, 
            INavigationService a 
        )
        {
            Contract.Requires(parameter != null);
            stockLogic = parameter;

            var stockModalNavigation = new ParameterNavigationService<BaseDTO, ViewModelBase>(navigationStore, ( parameter ) => new StockModalViewModel(a, new StockDTO()));

            addCommand = new ParameterNavigateCommand(stockModalNavigation);
            saveCommand = new SaveCommand(stockLogic);
            deleteCommand = new DeleteCommand(stockLogic);

            stockList = new ObservableCollection<StockViewDTO>();

            getAllStock();
        }


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

        public ICollectionView dataGridSource
        {
            get { return DataGridSource.View; }
        }

        public ObservableCollection<StockViewDTO> stockList
        {
            get
            {
                return _stockList;
            }
            set
            {
                _stockList = value;
                OnPropertyChanged(nameof(stockList));
            }
        }

        public void getAllStock()
        {
            getStockList(stockLogic.getAll());
        }

        public void searchStock(string parameter)
        {
            getStockList(((StockLogic)stockLogic).getAllOccurrencesOf(parameter));
        }


        private void getStockList(List<BaseDTO> list)
        {
            var stocks = new ObservableCollection<StockViewDTO>();
            list.ForEach(element => stocks.Add((StockViewDTO)element));
            stockList = stocks;
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
            var element = e.Item as StockViewDTO;
            if (element != null)
            {
                if(((StockLogic)stockLogic).searchLogic(element, searchText))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        private bool validateSearchString(string parameter)
        {
            Contract.Requires(parameter != null);
            bool ok = true;

            if (parameter.Trim().Equals("B�scar") || parameter.Trim().Equals(""))
            {
                ok = false;
            }

            return ok;
        }
        
        private CollectionViewSource DataGridSource
        {
            get
            {
                if (_dataGridSource == null)
                {
                    _dataGridSource = new CollectionViewSource();
                    _dataGridSource.Source = stockList;
                }
                return _dataGridSource;
            }
        }

    }
}
using Domain.Entities;
using Domain.Logic;
using MVVMGenericStructure.Services;
using System;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Command;
using WPF.Command.Navigation;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class ProductSelectionModalViewModel : ModalViewModel
    {
        public string titleBar { get; }

        public EntityStore entityStore { get; set; }

        public ProductSelectionModalViewModel(EntityStore _entityStore , INavigationService closeModalNavigationService ) : base(closeModalNavigationService)
        {
            titleBar = "Selecionar un producto";

            entityStore = _entityStore;
            GoCommand = new RelayCommand(parameter => go((Product)parameter));
        }

        public ICommand GoCommand { get; }

        public void go( Product parameter )
        {
            new SelectEntityCommand(entityStore).Execute(parameter);
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
                search();
            }
        }

        public void search()
        {
            if (validateSearchString(searchText))
            {
                dataGridSource.Filter = DataGridSource_Filter;
            }
            else if (searchText.Equals(""))
            {
                dataGridSource.Filter = null;
            }
        }

        private bool validateSearchString(string parameter) => !parameter.Trim().Equals("Búscar") && !parameter.Trim().Equals("");

        private bool DataGridSource_Filter(object obj)
        {
            if (obj is Product element)
            {
                return searchLogic(element, searchText);
            }

            return false;
        }
        public bool searchLogic(Product element, string parameter) =>
            element.idProduct.ToString().Contains(parameter.Trim()) ||
            element.name.ToLower().StartsWith(parameter.Trim().ToLower());


        public ICollectionView dataGridSource => CollectionViewSource.GetDefaultView(entityStore._catalogue);
        public override void Dispose()
        {
            searchText = "";
            base.Dispose();
        }

    }
}

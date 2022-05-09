﻿using Domain.Entities;
using Domain.Logic;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Stores;

namespace WPF.ViewModel
{
    public class ProductViewModel : ViewModelGeneric<Product>
    {
        public INavigationService _navigationService;

        private ICommand OpenModalCommand { get; }

        public EntityStore entityStore { get; set; }


        public ProductViewModel(BaseLogic<Product> parameter, EntityStore _entityStore, INavigationService modalNavigationService) : base((ProductLogic)parameter)
        {
            _navigationService = modalNavigationService;
            OpenModalCommand = new NavigateCommand(_navigationService);

            AddModalCommand = new RelayCommand(parameter => addModal());
            EditModalCommand = new RelayCommand(parameter => editModal((Product)parameter)); 


            entityStore = _entityStore;
            entityStore.EntityEdited += OnEntityEdited;
            entityStore.EntityCreated += OnEntityCreated;
            entityStore.EntityDeleted += OnEntityDeleted;
        }


        public static ProductViewModel LoadViewModel(BaseLogic<Product> parameter, EntityStore _entityStore, INavigationService navigationService)
        {
            ProductViewModel viewModel = new ProductViewModel(parameter, _entityStore, navigationService);

            viewModel.LoadCatalogueCommand.Execute(null);

            return viewModel;
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

        private bool DataGridSource_Filter(object obj)
        {
            if (obj is Product element)
            {
                return ((ProductLogic)logic).searchLogic(element, searchText);
            }

            return false;
        }

        public ICollectionView dataGridSource => CollectionViewSource.GetDefaultView(catalogue);
           
   
        public ICommand AddModalCommand { get; }
        public void addModal()
        {
            entityStore.isEdition = false;
            entityStore.entity = null;
            OpenModalCommand.Execute(-1);
        }


        public ICommand EditModalCommand { get; }
        public void editModal(Product parameter)
        {
            entityStore.entity = parameter;
            entityStore.isEdition = true;
            OpenModalCommand.Execute(-1);
        }


        private ICommand _changeStatusCommand;
        public ICommand ChangeStatusCommand
        {
            get
            {
                if (_changeStatusCommand is null)
                    _changeStatusCommand = new RelayCommand(parameter => changeStatus((Product)parameter));

                return _changeStatusCommand;
            }
        }
        private void changeStatus(Product parameter)
        {
            if (parameter == null)
                return;

            bool flag = parameter.Status;

            if (parameter.Status)
            {
                var result = MessageBox
                    .Show("¿Está seguro de desactivar el producto '" + parameter.Name +
                    "'?\nTodas las ocurrencias de este producto serán ocultadas de los catalogos donde aparezca",
                    "Confirmar desactivación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) parameter.Status = false;
            }
            else
                parameter.Status = true;

            if (flag != parameter.Status)
            {
                entityStore.isEdition = true;
                OnEntityEdited(parameter);
            }
        }

        public override void Dispose()
        {
            entityStore.EntityEdited -= OnEntityEdited;
            entityStore.EntityCreated -= OnEntityCreated;
            entityStore.entity = null;
            base.Dispose();
        }

        private void OnEntityEdited(BaseEntity parameter)
        {
            SaveCommand((Product)parameter);
        }

        private void OnEntityCreated(BaseEntity parameter)
        {
            SaveCommand((Product)parameter);
        }
        
        private async void OnEntityDeleted(BaseEntity parameter)
        {
            await new DeleteCommand<Product>(logic).ExecuteAsync((Product)parameter);

            await updateCatalogue();
        }

        private async void SaveCommand(Product parameter)
        {
            logic.entity = parameter;
            await new SaveCommand<Product>(logic, canCreate).ExecuteAsync(entityStore.isEdition);
            //entityStore.RefreshChanges();
            await Initialize();
        }
    }
}

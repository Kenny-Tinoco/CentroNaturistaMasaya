﻿using Domain.Entities;
using Domain.Logic;
using Domain.Logic.Base;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;


namespace WPF.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private ICommand openModalCommand { get; }

        private readonly IMessenger messenger;

        private readonly EmployeeLogic logic;

        public ListingViewModel listingViewModel { get; }


        public EmployeeViewModel(ILogic _logic, IMessenger _messenger, INavigationService modalNavigation)
        {
            logic = (EmployeeLogic)_logic;

            listingViewModel = new ListingViewModel(GetEmployeeListing, SortEmployeeListing);

            openModalCommand = new NavigateCommand(modalNavigation);

            addModalCommand = new RelayCommand(o => AddModal());
            editModalCommand = new RelayCommand(parameter => EditModal((Employee)parameter));

            messenger = _messenger;
            messenger.Subscribe<EmployeeModalMessage>(this, MessageReceived);
        }



        public static EmployeeViewModel LoadViewModel(ILogic parameter, IMessenger messenger, INavigationService navigationService)
        {
            EmployeeViewModel viewModel = new(parameter, messenger, navigationService);

            viewModel.listingViewModel.loadCommand.Execute(null);

            return viewModel;
        }


        private void SortEmployeeListing(ICollectionView listing)
        {
            listing.SortDescriptions.Clear();
            listing.SortDescriptions
                .Add(new SortDescription(nameof(Employee.IdEmployee), ListSortDirection.Descending));
        }

        private async Task<IEnumerable<BaseEntity>> GetEmployeeListing()
        {
            return await logic.GetAll();
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

        private bool Filter(object obj)
        {
            if (obj is Employee element)
            {
                return logic.searchLogic(element, searchText);
            }

            return false;
        }

        public ICommand addModalCommand { get; }
        public void AddModal()
        {
            messenger.Send(new EmployeeMessage(null, false));

            openModalCommand.Execute(-1);
        }


        public ICommand editModalCommand { get; }
        public void EditModal(Employee parameter)
        {
            messenger.Send(new EmployeeMessage(parameter, true));

            openModalCommand.Execute(-1);
        }


        private ICommand _changeStatusCommand;
        public ICommand changeStatusCommand
        {
            get
            {
                if (_changeStatusCommand is null)
                    _changeStatusCommand = new RelayCommand(parameter => ChangeStatus((Employee)parameter));

                return _changeStatusCommand;
            }
        }
        private void ChangeStatus(Employee parameter)
        {
            if (parameter == null)
                return;

            bool flag = parameter.Status;

            if (parameter.Status)
            {
                var result = MessageBox
                    .Show("¿Está seguro de desactivar el empleado '" + parameter.Name +
                    "'?\nTodas las ocurrencias de este empleado serán ocultadas de los catalogos donde aparezca",
                    "Confirmar desactivación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) parameter.Status = false;
            }
            else
                parameter.Status = true;

            if (flag != parameter.Status)
                Save(parameter, true);
        }

        private void MessageReceived(object parameter)
        {
            var element = (EmployeeModalMessage)parameter;
            var isEdition = element.operation is Operation.update;

            if (element.operation is Operation.create or Operation.update)
                Save(element.entity, isEdition, element.viewModel);
            else
                Delete(element.entity.IdEmployee);
        }


        private async void Delete(int idEmployee)
        {
            await new DeleteCommand(logic).ExecuteAsync(idEmployee);

            listingViewModel.loadCommand.Execute(null);
        }

        private void Save(Employee parameter, bool isEdition, FormViewModel viewModel = null)
        {
            logic.entity = parameter;
            new SaveCommand(logic, viewModel).Execute(isEdition);

            listingViewModel.loadCommand.Execute(null);
        }

        public override void Dispose()
        {
            try
            {
                if (listingViewModel.listing != null)
                    listingViewModel.listing.Filter = null;
            }
            catch
            {
            }

            base.Dispose();
        }

    }
}

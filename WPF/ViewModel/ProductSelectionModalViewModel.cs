﻿using Domain.Entities;
using Domain.Logic;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Command.Crud;
using WPF.Command.Navigation;
using WPF.MVVMEssentials.Services;

namespace WPF.ViewModel
{
    public class ProductSelectionModalViewModel : ViewModelGeneric
    {
        public string titleBar { get; }

        public ICommand exitCommand { get; }
        public ICommand _goCommand;

        public BaseLogic<Product> logic { get; }


        public ProductSelectionModalViewModel(BaseLogic<Product> _logic, INavigationService closeModalNavigationService )
        {
            logic = _logic;
            logic.loadListRecordsCommand = new LoadRecordListCommand<Stock>(this);
            exitCommand = new ExitModalCommand(closeModalNavigationService);
            titleBar = "Selecionar un producto";
        }


        public static ProductSelectionModalViewModel LoadViewModel(BaseLogic<Product> _logic, INavigationService closeModalNavigationService )
        {
            ProductSelectionModalViewModel viewModel = new ProductSelectionModalViewModel(_logic, closeModalNavigationService);

            viewModel.logic.loadListRecordsCommand.Execute(null);

            return viewModel;
        }


        public override async Task Initialize()
        {
            logic.getListUpdates(await logic.getAll());
        }


        public ICommand goCommand
        {
            get
            {
                if (_goCommand == null)
                    _goCommand = new RelayCommand(parameter => go((Product)parameter), null);

                return _goCommand;
            }
        }

        public void go( Product parameter )
        {
            logic.currentDTO = parameter;
            exitCommand.Execute(-1);
        }

    }
}

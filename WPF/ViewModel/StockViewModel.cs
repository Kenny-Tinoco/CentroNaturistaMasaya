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
using WPF.Command.Generic;
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


        public StockViewModel(ILogic _logic, IMessenger _messenger, INavigationService formNavigationService, INavigationService stockKeepingNavigationService)
        {
            logic = (StockLogic)_logic;

            listingViewModel = new ListingViewModel(GetStockViewListing, SortStockViewListing, StockViewFilter);

            openFormCommand = new NavigateCommand(formNavigationService);
            openStockKeepingCommand = new NavigateCommand(stockKeepingNavigationService);

            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshStockChanges);

            viewType = Views.OnlyActive;
        }


        public static StockViewModel LoadViewModel(ILogic _logic, IMessenger _messenger, INavigationService formNavigationService, INavigationService stockKeepingNavigationService)
        {
            StockViewModel viewModel = new(_logic, _messenger, formNavigationService, stockKeepingNavigationService);

            viewModel.listingViewModel.loadCommand.Execute(null);

            return viewModel;
        }

        private async Task<IEnumerable<BaseEntity>> GetStockViewListing() =>
            await logic.viewsCollections.StockViewCatalog(viewType);

        private void SortStockViewListing(ICollectionView listing)
        {
            listing.SortDescriptions
                .Clear();

            listing.SortDescriptions
                .Add(new SortDescription(nameof(StockView.EntryDate), ListSortDirection.Descending));
        }

        private ICommand openStockKeepingCommand;
        public ICommand stockKeepingCommand => new RelayCommand(parameter =>
        {
            if (parameter is null)
                return;

            var element = (StockView)parameter;
            messenger.Send(new StockKeepingMessage((element.IdStock, element.Quantity)));

            openStockKeepingCommand.Execute(null);
        });

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
            var hasChangeableState = logic.HasChangeableState(idStock);

            if (!hasChangeableState)
                return;

            OpenForm(new StockMessage(logic.GetStock(idStock), true));
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

        private void Add() => OpenForm(new StockMessage(null, false));

        private void OpenForm(StockMessage message)
        {
            messenger.Send(message);

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
            NotifyChanges();
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

        private void NotifyChanges()
        {
            messenger.Send(Refresh.stock);
            messenger.Send(Refresh.sale);
        }

        private void RefreshStockChanges(object parameter)
        {
            if ((Refresh)parameter is not Refresh.stock)
                return;
            
            listingViewModel.loadCommand.Execute(null);
        }

        private bool StockViewFilter(object parameter, string text)
        {
            if (parameter is not StockView)
                return false;

            return StockLogic.SearchLogic((StockView)parameter, text);
        }

        private void Clear()
        {
            listingViewModel.listing.GroupDescriptions.Clear();
        }

        public override void Dispose()
        {
            if (listingViewModel.listing is not null)
                listingViewModel.listing.Filter = null;

            base.Dispose();
        }
    }
}
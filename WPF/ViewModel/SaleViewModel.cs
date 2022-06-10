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
using System.Windows.Input;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;
using WPF.ViewModel.Utilities;

namespace WPF.ViewModel
{
    public class SaleViewModel : ViewModelBase
    {
        public ICommand openFormCommand { get; }

        private readonly SaleLogic logic;

        public ListingViewModel listingViewModel { get; }


        public SaleViewModel(ILogic _logic, IMessenger _messenger, INavigationService formNavigation)
        {
            logic = (SaleLogic)_logic;

            listingViewModel = new ListingViewModel(GetSaleListing, SortSaleListing, SaleViewFilter);

            openFormCommand = new NavigateCommand(formNavigation);

            _messenger.Subscribe<Refresh>(this, RefreshListings);
            selectedItem = null;
        }


        public static SaleViewModel LoadViewModel(ILogic parameter, IMessenger messenger, INavigationService navigationService)
        {
            SaleViewModel viewModel = new(parameter, messenger, navigationService);

            viewModel.Load();

            return viewModel;
        }

        public void Load()
        {
            RefreshListings(Refresh.employee);

            RefreshListings(Refresh.sale);
        }

        private async Task LoadEmployees()
        {
            employeeListing = new();
            var list = await logic.GetEmployees();

            foreach (var (name, idEmployee) in list)
                employeeListing.Add(new { name = name, idEmployee = idEmployee });
        }

        private void SortSaleListing(ICollectionView listing)
        {
            listing.SortDescriptions.Clear();
            listing.SortDescriptions
                .Add(new SortDescription(nameof(Sale.Date), ListSortDirection.Descending));
        }

        private async Task<IEnumerable<BaseEntity>> GetSaleListing() => 
            await logic.viewsCollections.SaleViewCatalog
            (
                periodSelected is null ? Periods.Today : periodSelected.period, 
                (int)(employeeSelected is null ? -1 : employeeSelected.idEmployee)
            );


        private async void RefreshListings(object parameter)
        {
            if (parameter is Refresh.sale)
                listingViewModel.loadCommand.Execute(null);
            else if (parameter is Refresh.employee)
                await LoadEmployees();
        }

        private SaleView _selectedItem;
        public SaleView selectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;

                if (_selectedItem is not null)
                    GetDetails();

                OnPropertyChanged(nameof(selectedItem));
                OnPropertyChanged(nameof(anItemIsSelected));
            }
        }

        private async void GetDetails() =>
            saleDetails = await logic.GetDetails(_selectedItem.IdSale);

        public bool anItemIsSelected => selectedItem is not null;

        private IEnumerable<SaleDetailView> _saleDetails;
        public IEnumerable<SaleDetailView> saleDetails
        {
            get => _saleDetails;
            set
            {
                _saleDetails = value;
                OnPropertyChanged(nameof(saleDetails));
            }
        }

        private List<dynamic> _employeeListing;
        public List<dynamic> employeeListing
        {
            get => _employeeListing;
            set
            {
                _employeeListing = value;
                OnPropertyChanged(nameof(employeeListing));

                OnPropertyChanged(nameof(employeeSelected));
            }
        }

        private dynamic _employeeSelected;
        public dynamic employeeSelected
        {
            get => _employeeSelected;
            set
            {
                _employeeSelected = value;
                OnPropertyChanged(nameof(employeeSelected));

                RefreshListings(Refresh.sale);
            }
        }

        private List<Period> _periodListing;
        public List<Period> periodListing
        {
            get
            {
                if (_periodListing is null)
                    _periodListing = new List<Period>
                    {
                        new(Periods.Today,"Hoy"),
                        new(Periods.ThisWeek, "Esta semana"),
                        new(Periods.ThisMonth, "Este mes"),
                        new(Periods.AllTime, "Todo el tiempo")
                    };

                return _periodListing;
            }
        }

        private Period _periodSelected;
        public Period periodSelected
        {
            get => _periodSelected;
            set
            {
                _periodSelected = value;
                OnPropertyChanged(nameof(periodSelected));

                RefreshListings(Refresh.sale);
            }
        }


        public ICommand closeDetails => new RelayCommand(o =>
        {
            selectedItem = null;
        });

        private bool SaleViewFilter(object parameter, string text)
        {
            if (parameter is not SaleView)
                return false;

            return SaleLogic.SearchLogic((SaleView)parameter, text);
        }
    }
}

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
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

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

        public async void Load()
        {
            await LoadEmployees();
            listingViewModel.loadCommand.Execute(null);
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
                .Add(new SortDescription(nameof(Sell.IdSell), ListSortDirection.Descending));
        }

        private async Task<IEnumerable<BaseEntity>> GetSaleListing() =>
            await logic.viewsCollections.SellViewCatalog(periodSelected.period, employeeSelected.idEmployee);

        private async void RefreshListings(object parameter)
        {
            if (parameter is Refresh.sale)
                listingViewModel.loadCommand.Execute(null);
            else if (parameter is Refresh.employee)
                await LoadEmployees();
        }

        private SellView _selectedItem;
        public SellView selectedItem
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

        private async void GetDetails()
        {
            saleDetails = await logic.GetDetails(_selectedItem.IdSell);
        }

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
            get
            {
                if (_employeeSelected is null && employeeListing.Count != 0)
                {
                    _employeeSelected = new ExpandoObject();
                    _employeeSelected = employeeListing[0];
                }

                return _employeeSelected;
            }
            set
            {
                _employeeSelected = value;
                OnPropertyChanged(nameof(employeeSelected));

                listingViewModel.loadCommand.Execute(null);
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
                        new(Periods.today,"Hoy"),
                        new(Periods.thisWeek, "Esta semana"),
                        new(Periods.thisMonth, "Este mes"),
                        new(Periods.allTime, "Todo el tiempo")
                    };

                return _periodListing;
            }
        }

        private Period _periodSelected;
        public Period periodSelected
        {
            get
            {
                if (_periodSelected is null)
                    _periodSelected = periodListing[0];

                return _periodSelected;
            }
            set
            {
                _periodSelected = value;
                OnPropertyChanged(nameof(periodSelected));

                listingViewModel.loadCommand.Execute(null);
            }
        }


        public ICommand closeDetails => new RelayCommand(o =>
        {
            selectedItem = null;
        });

        private bool SaleViewFilter(object parameter, string text)
        {
            if (parameter is not SellView)
                return false;

            return SaleLogic.SearchLogic((SellView)parameter, text);
        }

        public override void Dispose()
        {
            if (listingViewModel.listing is not null)
                listingViewModel.listing.Filter = null;

            base.Dispose();
        }
    }

    public class Period
    {
        public Period(Periods period, string name)
        {
            this.name = name;
            this.period = period;
        }

        public string name { get; }
        public Periods period { get; }
    }
}

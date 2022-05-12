using Domain.Entities;
using Domain.Logic;
using MVVMGenericStructure.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;

namespace WPF.ViewModel
{
    public class PresentationModalViewModel : ViewModelGeneric<Presentation>
    {
        public string titleBar => "Presentaciones";

        private ICommand CloseModalCommand;

        private IMessenger messenger;

        public PresentationModalViewModel(BaseLogic<Presentation> logic, IMessenger _messenger, INavigationService closeModal) : base((PresentationLogic)logic)
        {
            messenger = _messenger;

            CloseModalCommand = new ExitModalCommand(closeModal);

            Reset();
        }

        public static PresentationModalViewModel LoadViewModel(BaseLogic<Presentation> logic, IMessenger _messenger, INavigationService closeModal)
        {
            PresentationModalViewModel viewModel = new(logic, _messenger, closeModal);

            viewModel.loadCatalogueCommand.Execute(null);

            return viewModel;
        }



        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand is null)
                {
                    _saveCommand = new RelayCommand(parameter => RunSaveCommand((bool)parameter));
                }

                return _saveCommand;
            }
        }
        private void RunSaveCommand(bool isEdition)
        {
            Save(isEdition);
            Reset();
        }

        private void Save(bool isEdition)
        {
            Save(GetEntity(), isEdition);
            RefreshCatalogues(isEdition);
        }
        private async void Save(Presentation parameter, bool isEdition)
        {
            logic.entity = parameter;
            await new SaveCommand<Presentation>(logic, canCreate).ExecuteAsync(isEdition);

            await Initialize();
        }

        private void RefreshCatalogues(bool isEdition)
        {
            messenger.Send(Refresh.presentation);

            if (isEdition)
                messenger.Send(Refresh.stock);
        }

        private Presentation GetEntity()
        {
            return new Presentation()
            {
                IdPresentation = id,
                Name = name,
                Status = status
            };
        }

        public ICommand ExitCommand => new RelayCommand(o => Exit());
        private void Exit()
        {
            Reset();
            CloseModalCommand.Execute(null);
        }


        private ICommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand is null)
                    _resetCommand = new RelayCommand(o => Reset());

                return _resetCommand;
            }
        }
        private void Reset()
        {
            id = 0;
            name = string.Empty;
            status = true;
            isEditable = false;
        }


        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (_editCommand is null)
                    _editCommand = new RelayCommand(parameter => Edit((Presentation)parameter));

                return _editCommand;
            }
        }
        private void Edit(Presentation parameter)
        {
            id = parameter.IdPresentation;
            name = parameter.Name;
            status = parameter.Status;

            isEditable = true;
        }


        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand is null)
                    _deleteCommand = new RelayCommand(o => Delete());

                return _deleteCommand;
            }
        }
        private async void Delete()
        {
            var result = MessageBox
                .Show("¿Está seguro de eliminar esta presentación?\n" +
                      "Se desencadenará una eliminación en cascada de todos los registros que tengan alguna relación con esta presentación.\n\n" +
                      "Antes de eliminarla considere la opción de deshabilitar esta presentación, dicha opción oculta todas las ocurrencias de la " +
                      "sin hacer eliminaciones.",
                      "Confirmar Eliminación", MessageBoxButton.YesNo);

            if (result is not MessageBoxResult.Yes)
                return;
            
            await new DeleteCommand<Presentation>(logic).ExecuteAsync(entity.IdPresentation);
            
            Reset();
            await Initialize();
            RefreshCatalogues(true);
        }


        private ICommand _changeStatusCommand;
        public ICommand ChangeStatusCommand
        {
            get
            {
                if (_changeStatusCommand is null)
                    _changeStatusCommand = new RelayCommand(parameter => ChangeStatus((Presentation)parameter));

                return _changeStatusCommand;
            }
        }
        private void ChangeStatus(Presentation parameter)
        {
            if (parameter == null)
                return;

            bool flag = parameter.Status;

            if (parameter.Status)
            {
                var result = MessageBox
                    .Show("¿Está seguro de desactivar la presentacion '" + parameter.Name +
                    "'?\nTodas las ocurrencias de esta presentación serán ocultadas de los catalogos donde aparezca",
                    "Confirmar desactivación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) parameter.Status = false;
            }
            else
                parameter.Status = true;

            if (flag != parameter.Status)
            {
                Save(parameter,true);
                RefreshCatalogues(true);
            }
        }


        private Presentation _entity;
        private Presentation entity
        {
            get
            {
                if (_entity is null)
                    _entity = new Presentation();
                return _entity;
            }
        }

        public int id
        {
            get => entity.IdPresentation;
            set
            {
                entity.IdPresentation = value;
                OnPropertyChanged(nameof(id));
            }
        }
        public string name
        {
            get => entity.Name;
            set
            {
                entity.Name = value;
                _errorsViewModel.ClearErrors(nameof(name));

                if (string.IsNullOrEmpty(entity.Name))
                    _errorsViewModel.AddError(nameof(name), "Debe ingresar un nombre");

                OnPropertyChanged(nameof(name));
            }
        }
        private bool status
        {
            get => entity.Status;
            set => entity.Status = value;
        }



        private ICollectionView _dataGridSource;
        public ICollectionView dataGridSource
        {
            get
            {
                if (_dataGridSource != null)
                    Sort();

                return _dataGridSource;
            }
            set
            {
                _dataGridSource = value;
                OnPropertyChanged(nameof(dataGridSource));
            }
        }

        private void Sort()
        {
            _dataGridSource.SortDescriptions
                .Clear();
            _dataGridSource.SortDescriptions
                .Add(new SortDescription(nameof(Presentation.IdPresentation), ListSortDirection.Descending));
        }
        public override async Task Initialize()
        {
            dataGridSource =
                CollectionViewSource.
                GetDefaultView(await logic.GetAll());
            Sort();
        }
    }
}

using Domain.Entities;
using Domain.Logic;
using MVVMGenericStructure.Services;
using System.Windows;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Stores;

namespace WPF.ViewModel
{
    public class PresentationModalViewModel : ViewModelGeneric<Presentation>
    {
        public string titleBar => "Presentaciones";

        private ICommand Save;

        private ICommand CloseModalCommand;

        private EntityStore entityStore;

        public PresentationModalViewModel(BaseLogic<Presentation> parameter, EntityStore _entityStore, INavigationService closeModalNavigationService) : base((PresentationLogic)parameter)
        {
            entityStore = _entityStore;

            Save = new SaveCommand<Presentation>(logic, canCreate);
            CloseModalCommand = new ExitModalCommand(closeModalNavigationService);

            if(!isEditable)
                reset();
        }

        public static PresentationModalViewModel LoadViewModel(BaseLogic<Presentation> parameter, EntityStore _entityStore, INavigationService closeModalNavigationService)
        {
            PresentationModalViewModel viewModel = new PresentationModalViewModel(parameter, _entityStore, closeModalNavigationService);

            viewModel.LoadCatalogueCommand.Execute(null);

            return viewModel;
        }


        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand is null)
                    _saveCommand = new RelayCommand(parameter => save((bool)parameter));

                return _saveCommand;
            }
        }
        private void save(bool parameter)
        {
            saveAux(parameter);
            reset();
        }

        private async void saveAux(bool parameter)
        {
            logic.entity = getEntity();
            Save.Execute(parameter);
            await updateCatalogue();
            //entityStore.RefreshChanges();
        }
        
        private Presentation getEntity()
        {
            return new Presentation()
            {
                IdPresentation = id,
                Name = name,
                Status = status
            };
        }

        public ICommand ExitCommand => new RelayCommand(parameter => exit());
        private void exit()
        {
            reset();
            CloseModalCommand.Execute(null);
        }


        private ICommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand is null)
                    _resetCommand = new RelayCommand(parameter => reset());

                return _resetCommand;
            }
        }
        private void reset()
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
                    _editCommand = new RelayCommand(parameter => edit((Presentation)parameter));

                return _editCommand;
            }
        }
        private void edit(Presentation parameter)
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
                    _deleteCommand = new RelayCommand(parameter => delete());

                return _deleteCommand;
            }
        }
        private async void delete()
        {
            var result = MessageBox
                .Show("¿Está seguro de eliminar esta presentación?\n" +
                      "Se desencadenará una eliminación en cascada de todos los registros que tengan alguna relación con esta presentación.\n\n" +
                      "Antes de eliminarla considere la opción de deshabilitar esta presentación, dicha opción oculta todas las ocurrencias de la " +
                      "sin hacer eliminaciones.",
                      "Confirmar Eliminación", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                await new DeleteCommand<Presentation>(logic).ExecuteAsync(entity);

                reset();
                await updateCatalogue();
            }
        }


        private ICommand _changeStatusCommand;
        public ICommand ChangeStatusCommand
        {
            get
            {
                if (_changeStatusCommand is null)
                    _changeStatusCommand = new RelayCommand(parameter => changeStatus((Presentation)parameter));

                return _changeStatusCommand;
            }
        }
        private void changeStatus(Presentation parameter)
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
                edit(parameter);
                saveAux(true);
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
    }
}

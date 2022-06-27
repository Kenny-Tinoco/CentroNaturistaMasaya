using Domain.Entities;
using Domain.Logic;
using Domain.Logic.Base;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Command.Generic;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class PresentationModalViewModel : ModalFormViewModel
    {
        public string titleBar => "Presentaciones";

        private readonly IMessenger messenger;

        public ListingViewModel listingViewModel { get; }

        private PresentationLogic logic { get; }


        public PresentationModalViewModel(ILogic _logic, IMessenger _messenger, INavigationService closeModal) : base(closeModal)
        {
            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshListing);

            logic = (PresentationLogic)_logic;

            listingViewModel = new ListingViewModel(GetPresentationListing, SortPresentationListing);

            Reset();
        }


        public static PresentationModalViewModel LoadViewModel(ILogic logic, IMessenger _messenger, INavigationService closeModal)
        {
            PresentationModalViewModel viewModel = new(logic, _messenger, closeModal);

            viewModel.listingViewModel.loadCommand.Execute(null);

            return viewModel;
        }

        private void SortPresentationListing(ICollectionView listing)
        {
            listing.SortDescriptions.Clear();
            listing.SortDescriptions
                .Add(new SortDescription(nameof(Presentation.IdPresentation), ListSortDirection.Descending));
        }

        private async Task<IEnumerable<BaseEntity>> GetPresentationListing() => await logic.GetAll();

        private ICommand _saveCommand;
        public ICommand saveCommand
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
        private async void RunSaveCommand(bool isEdition)
        {
            await Save(isEdition);
            Reset();
        }

        private async Task Save(bool isEdition)
        {
            await Save(GetEntity(), isEdition);
            NotifyChanges(isEdition);
        }

        private async Task Save(Presentation parameter, bool isEdition)
        {
            logic.entity = parameter;

            await new SaveCommand(logic).ExecuteAsync(isEdition);

            RefreshListing(Refresh.presentation);
        }

        private void NotifyChanges(bool isEdition)
        {
            messenger.Send(Refresh.presentation);

            if (isEdition)
                messenger.Send(Refresh.stock);
        }

        private void RefreshListing(object parameter)
        {
            if(parameter is Refresh.presentation) 
                listingViewModel.loadCommand.Execute(null);
        }

        private Presentation GetEntity()
        {
            return new Presentation()
            {
                IdPresentation = id,
                Name = name.Trim(),
                Status = status
            };
        }

        public ICommand closeCommand => new RelayCommand(o => Exit());
        private void Exit()
        {
            Reset();
            exitCommand.Execute(null);
        }


        private ICommand _resetCommand;
        public ICommand resetCommand
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
        public ICommand editCommand
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
        public ICommand deleteCommand
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

            await new DeleteCommand(logic).ExecuteAsync(entity.IdPresentation);

            Reset();

            RefreshListing(Refresh.presentation);

            NotifyChanges(true);
        }


        private ICommand _changeStatusCommand;
        public ICommand changeStatusCommand
        {
            get
            {
                if (_changeStatusCommand is null)
                    _changeStatusCommand = new RelayCommand(parameter => ChangeStatus((Presentation)parameter));

                return _changeStatusCommand;
            }
        }
        private async void ChangeStatus(Presentation parameter)
        {
            if (parameter is null)
                return;

            bool flag = parameter.Status;

            if (parameter.Status)
            {
                var result = MessageBox
                    .Show("¿Está seguro de desactivar la presentacion '" + parameter.Name +
                    "'?\nTodas las ocurrencias de esta presentación serán ocultadas de los catalogos donde aparezca",
                    "Confirmar desactivación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) 
                    parameter.Status = false;
            }
            else
                parameter.Status = true;

            if (flag != parameter.Status)
            {
                await Save(parameter, true);
                NotifyChanges(true);
            }
        }

        private Presentation entity
        {
            get
            {
                if (_entity is null)
                    _entity = new Presentation();
                return (Presentation)_entity;
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
                errorsViewModel.ClearErrors(nameof(name));

                if (string.IsNullOrEmpty(entity.Name))
                    errorsViewModel.AddError(nameof(name), "Debe ingresar un nombre");

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

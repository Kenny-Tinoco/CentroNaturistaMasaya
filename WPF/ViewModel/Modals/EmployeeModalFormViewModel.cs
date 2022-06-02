using Domain.Entities;
using MVVMGenericStructure.Services;
using System.Windows;
using System.Windows.Input;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class EmployeeModalFormViewModel : ModalFormViewModel
    {
        private readonly IMessenger messenger;


        public EmployeeModalFormViewModel(IMessenger _messenger, INavigationService closeModal) : base(closeModal)
        {
            messenger = _messenger;
            messenger.Subscribe<EmployeeMessage>(this, EmployeeMessageSent);
        }


        private void EmployeeMessageSent(object parameter)
        {
            isEditable = ((EmployeeMessage)parameter).isEdition;

            var element = ((EmployeeMessage)parameter).entity;

            if (element is null)
                ResetEntity();
            else
                entity = new Employee()
                {
                    IdEmployee = element.IdEmployee,
                    Name = element.Name,
                    LastName = element.LastName,
                    Address = element.Address,
                    Status = element.Status
                };
        }

        private void ResetEntity()
        {
            entity = new Employee()
            {
                IdEmployee = 0,
                Name = "",
                LastName = "",
                Address = "",
                Status = true
            };

            OnPropertyChanged(nameof(name));
            OnPropertyChanged(nameof(lastName));
        }
        private Employee GetEntity()
        {
            return new Employee()
            {
                IdEmployee = entity.IdEmployee,
                Name = name.Trim(),
                LastName = lastName.Trim(),
                Address = address.Trim(),
                Status = entity.Status
            };
        }

        public Employee entity
        {
            get => (Employee)_entity;
            set
            {
                _entity = value;
                OnPropertyChanged(nameof(entity));
            }
        }

        public string titleBar => isEditable ? "Editar Empleado" : "Agregar Empleado";

        public ICommand _deleteCommand;
        public ICommand deleteCommand
        {
            get
            {
                if (_deleteCommand is null)
                    _deleteCommand = new RelayCommand(o => Delete());

                return _deleteCommand;
            }
        }
        public void Delete()
        {
            var result = MessageBox
                .Show("¿Está seguro de eliminar este Empleado?\n" +
                      "Se desencadenará una eliminación en cascada de todos los registros que tengan alguna relación con este producto.\n\n" +
                      "Antes de eliminarlo considere la opción de deshabilitar este Empleado, dicha opción oculta todas las ocurrencias del " +
                      "mismo sin hacer eliminaciones.",
                      "Confirmar Eliminación", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
                return;

            messenger.Send(new EmployeeModalMessage(entity, Operation.delete, this));
            exitCommand.Execute(null);
        }


        public ICommand _saveCommand;
        public ICommand saveCommand
        {
            get
            {
                if (_saveCommand is null)
                    _saveCommand = new RelayCommand(parameter => Save((bool)parameter));

                return _saveCommand;
            }
        }
        public void Save(bool isEdition)
        {
            if (!isEdition)
            {
                messenger.Send(new EmployeeModalMessage(GetEntity(), Operation.create, this));
                ResetEntity();
            }
            else
            {
                messenger.Send(new EmployeeModalMessage(GetEntity(), Operation.update, this));
                exitCommand.Execute(null);
            }
        }

        public string name
        {
            get
            {
                if (string.IsNullOrEmpty(entity.Name))
                    errorsViewModel.AddError(nameof(name), "El nombre es nulo o vacio");

                return entity.Name;
            }
            set
            {
                entity.Name = value;
                errorsViewModel.ClearErrors(nameof(name));

                if (string.IsNullOrEmpty(entity.Name.Trim()))
                    errorsViewModel.AddError(nameof(name), "Debe ingresar algun nombre");

                OnPropertyChanged(nameof(name));
            }
        }

        public string lastName
        {
            get
            {
                if (string.IsNullOrEmpty(entity.LastName.Trim()))
                    errorsViewModel.AddError(nameof(lastName), "El apellido es nulo o vacio");

                return entity.LastName;
            }
            set
            {
                entity.LastName = value;
                errorsViewModel.ClearErrors(nameof(lastName));

                if (string.IsNullOrEmpty(entity.LastName.Trim()))
                    errorsViewModel.AddError(nameof(lastName), "Debe ingresar algun apellido");

                OnPropertyChanged(nameof(lastName));
            }
        }

        public string address
        {
            get
            {
                if (string.IsNullOrEmpty(entity.Address.Trim()))
                    errorsViewModel.AddError(nameof(address), "La dirección es nula o vacia");

                return entity.Address;
            }
            set
            {
                entity.Address = value;
                errorsViewModel.ClearErrors(nameof(address));

                if (string.IsNullOrEmpty(entity.Address.Trim()))
                    errorsViewModel.AddError(nameof(address), "Debe ingresar una dirección");

                OnPropertyChanged(nameof(address));
            }
        }
    }
}

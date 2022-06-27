using Domain.Entities;
using Domain.Logic.Base;
using MVVMGenericStructure.Services;
using System.Collections.ObjectModel;
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
    public class PatientModalFormViewModel : ModalFormViewModel
    {
        private readonly IMessenger messenger;

        private readonly ProviderPhoneLogic logic = null!;

        public PatientModalFormViewModel(IMessenger _messenger, INavigationService closeModal) : base(closeModal)
        {

            messenger = _messenger;
            messenger.Subscribe<ProviderMessage>(this, ProviderMessageSent);
        }

        private async void ProviderMessageSent(object parameter)
        {
            isEditable = ((ProviderMessage)parameter).isEdition;

            var element = ((ProviderMessage)parameter).entity;

            if (!isEditable)
                ResetEntity();
            else
            {
                entity = new Provider()
                {
                    IdProvider = element.IdProvider,
                    Name = element.Name,
                    Address = element.Address,
                    Status = element.Status,
                    Ruc = element.Ruc
                };

                await RefreshProviderPhones();
            }
        }

        private void ResetEntity()
        {
            entity = new Provider()
            {
                IdProvider = 0,
                Name = "",
                Address = "",
                Status = true,
                Ruc = ""
            };

            _providerPhones = null;

            OnPropertyChanged(nameof(name));
            OnPropertyChanged(nameof(address));
            OnPropertyChanged(nameof(ruc));
            OnPropertyChanged(nameof(providerPhones));
        }

        private Provider GetEntity()
        {
            var element = new Provider()
            {
                IdProvider = entity.IdProvider,
                Name = name.Trim(),
                Address = address.Trim(),
                Status = entity.Status,
                Ruc = ruc
            };

            if (!isEditable)
                foreach (var item in providerPhones)
                    element.ProviderPhones.Add(item);

            return element;
        }

        public Provider entity
        {
            get => (Provider)_entity;
            set
            {
                _entity = value;
                OnPropertyChanged(nameof(entity));
            }
        }

        public string titleBar => isEditable ? "Editar Proveedor" : "Agregar nuevo proveedor";

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
                .Show("¿Está seguro de eliminar este proveedor?\n" +
                      "Se desencadenará una eliminación en cascada de todos los registros que tengan alguna relación con este Proveedor.\n\n" +
                      "Antes de eliminarlo considere la opción de deshabilitarlo, dicha opción oculta todas las ocurrencias del " +
                      "mismo sin hacer eliminaciones.",
                      "Confirmar Eliminación", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
                return;

            messenger.Send(new ProviderModalMessage(entity, Operation.delete, this));

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
                messenger.Send(new ProviderModalMessage(GetEntity(), Operation.create, this));
                ResetEntity();
            }
            else
            {
                messenger.Send(new ProviderModalMessage(GetEntity(), Operation.update, this));
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
                    errorsViewModel.AddError(nameof(name), "Debe ingresar un nombre");

                OnPropertyChanged(nameof(name));
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

        public string ruc
        {
            get
            {
                if (string.IsNullOrEmpty(entity.Ruc.Trim()))
                    errorsViewModel.AddError(nameof(ruc), "El RUC es nulo o vacio");

                return entity.Ruc;
            }
            set
            {
                entity.Ruc = value;
                errorsViewModel.ClearErrors(nameof(ruc));

                if (string.IsNullOrEmpty(entity.Ruc.Trim()))
                    errorsViewModel.AddError(nameof(ruc), "Debe ingresar un ruc");

                OnPropertyChanged(nameof(ruc));
            }
        }

        private string _phone;
        public string phone
        {
            get
            {
                if (providerPhones.Count == 0)
                    errorsViewModel.AddError(nameof(phone), "Debe ingresar al menos un teléfono");

                return _phone;
            }
            set
            {
                _phone = value;
                errorsViewModel.ClearErrors(nameof(phone));
                if (IsRepeatedPhone(_phone))
                    errorsViewModel.AddError(nameof(phone), "Este teléfono ya está asociado a este proveedor");

                OnPropertyChanged(nameof(phone));
            }
        }

        private ObservableCollection<ProviderPhone> _providerPhones;
        public ObservableCollection<ProviderPhone> providerPhones
        {
            get
            {
                if (_providerPhones is null)
                    _providerPhones = new ObservableCollection<ProviderPhone>();

                return _providerPhones;
            }
            set
            {
                _providerPhones = value;
                OnPropertyChanged(nameof(providerPhones));
            }
        }

        private ICommand _addPhoneCommand;
        public ICommand addPhoneCommand
        {
            get
            {
                if (_addPhoneCommand is null)
                    _addPhoneCommand = new RelayCommand(o => AddPhone());

                return _addPhoneCommand;
            }
        }

        private async void AddPhone()
        {
            if (string.IsNullOrWhiteSpace(phone) || IsRepeatedPhone(phone))
                return;

            var element = new ProviderPhone()
            {
                Phone = phone
            };

            if (isEditable)
            {
                element.IdProvider = entity.IdProvider;

                logic.entity = element;

                await new SaveCommand(logic).ExecuteAsync(false);

                await RefreshProviderPhones();
            }
            else
            {
                providerPhones.Add(element);
            }

            phone = string.Empty;
        }

        private bool IsRepeatedPhone(string parameter)
        {
            if (providerPhones.Count == 0)
                return false;

            if (parameter is null)
                return true;

            foreach (ProviderPhone item in providerPhones)
                if (item.Phone.Equals(parameter))
                    return true;

            return false;
        }

        private ICommand _editPhoneCommand;
        public ICommand editPhoneCommand
        {
            get
            {
                if (_editPhoneCommand is null)
                    _editPhoneCommand = new RelayCommand(parameter => EditPhone((ProviderPhone)parameter));

                return _editPhoneCommand;
            }
        }

        private async void EditPhone(ProviderPhone element)
        {
            if (phone.Equals(element.Phone))
            {
                phone = string.Empty;
                itemSelected = null;
                return;
            }

            element.Phone = phone;

            if (isEditable)
            {
                logic.entity = element;
                await new SaveCommand(logic).ExecuteAsync(true);

                await RefreshProviderPhones();
            }
            else
            {
                providerPhones.Remove(element);
                providerPhones.Add(element);
            }

            phone = string.Empty;
            itemSelected = null;
        }


        private ICommand _deletePhoneCommand;
        public ICommand deletePhoneCommand
        {
            get
            {
                if (_deletePhoneCommand is null)
                    _deletePhoneCommand = new RelayCommand(parameter => DeletePhone((ProviderPhone)parameter));

                return _deletePhoneCommand;
            }
        }

        private async void DeletePhone(ProviderPhone element)
        {
            if (element == null)
                return;

            if (isEditable)
            {
                await new DeleteCommand(logic).ExecuteAsync(element.IdProviderPhone);

                await RefreshProviderPhones();
            }
            else
            {
                providerPhones.Remove(element);
            }

            phone = string.Empty;
            itemSelected = null;
        }

        private ProviderPhone _itemSelected;
        public ProviderPhone itemSelected
        {
            get
            {
                return _itemSelected;
            }
            set
            {
                _itemSelected = value;

                if (_itemSelected is not null)
                    phone = _itemSelected.Phone;

                OnPropertyChanged(nameof(itemSelected));
                OnPropertyChanged(nameof(isEditionOrDelete));
                OnPropertyChanged(nameof(isAdd));
            }
        }

        public bool isAdd => !isEditionOrDelete;
        public bool isEditionOrDelete => itemSelected is not null;

        private async Task RefreshProviderPhones()
        {
            var list = await logic.GetWhere(entity.IdProvider);

            providerPhones.Clear();
            foreach (var item in list)
                providerPhones.Add(item);

            phone = string.Empty;
        }
    }
}

using Domain.Entities;
using Domain.Logic;
using Domain.Logic.Base;
using MVVMGenericStructure.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using WPF.Command.Generic;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class StockKeepingViewModel : ModalFormViewModel
    {
        private readonly StockKeepingLogic logic;
        private readonly IMessenger messenger;
        public StockKeepingViewModel(IMessenger _messenger, ILogic _logic, INavigationService closeModal) : base(closeModal)
        {
            logic = (StockKeepingLogic)_logic;
            concept = true;
            messenger = _messenger;
            messenger.Subscribe<StockKeepingMessage>(this, MessageSent);
        }

        private void MessageSent(object parameter)
        {
            var element = ((StockKeepingMessage)parameter).message;

            idStock = element.idStock;
            currentQuantity = element.quantity;
        }

        private int _quantity;
        public int quantity
        {
            get
            {
                errorsViewModel.ClearErrors(nameof(quantity));

                if (!concept && _quantity > currentQuantity)
                    errorsViewModel.AddError(nameof(quantity), "No hay suficiente cantidad en stock");

                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(quantity));
                
                errorsViewModel.ClearErrors(nameof(quantity));

                if (_quantity < 0)
                    errorsViewModel.AddError(nameof(quantity), "Ingrese una cantidad positiva");
                if (_quantity == 0)
                    errorsViewModel.AddError(nameof(quantity), "Ingrese una cantidad");
                if (!concept && _quantity > currentQuantity)
                    errorsViewModel.AddError(nameof(quantity), "No hay suficiente cantidad en stock");
            }
        }

        private bool _concept;
        public bool concept
        {
            get => _concept;
            set
            {
                _concept = value;

                OnPropertyChanged(nameof(concept)); 
                OnPropertyChanged(nameof(quantity));
            }
        }

        private string _description;
        public string description
        {
            get
            {
                errorsViewModel.ClearErrors(nameof(description));

                if (string.IsNullOrEmpty(_description))
                    errorsViewModel.AddError(nameof(description), "Ingrese una descripción para este cambio.\n " +
                        "Puede utilizar las descripciones por defecto en el combobox.");
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(description));

                errorsViewModel.ClearErrors(nameof(description));

                if (string.IsNullOrEmpty(_description))
                {
                    errorsViewModel.AddError(nameof(description), "Ingrese una descripción para este cambio.\n" +
                        "Puede utilizar las descripciones por defecto en el combobox.");

                    selectedDescription = string.Empty;
                }
            }
        }

        private string _selectedDescription;
        public string selectedDescription
        {
            get => _selectedDescription;
            set
            {
                _selectedDescription = value;

                if (!string.IsNullOrEmpty(_selectedDescription))
                    description = _selectedDescription;

                OnPropertyChanged(nameof(selectedDescription));
            }
        }
        
        public int idStock { get; private set; }
        public int currentQuantity { get; private set; }
        public string titleBar => "Mantenimiento de stock";

        public ICommand updateQuantityComand => new RelayCommand(async o =>
        {
            logic.entity = GetEntity();
            await new SaveCommand(logic, this).ExecuteAsync(false);

            NotifyChanges();
            exitCommand.Execute(null);
        });

        private void NotifyChanges()
        {
            messenger.Send(Refresh.stock);
            messenger.Send(Refresh.product);
        }

        private StockKeeping GetEntity()
        {
            var element = new StockKeeping()
            {
                IdStock = idStock,
                Quantity = quantity,
                Concept = concept,
                Description = description,
                Date = DateTime.Now
            };
            return element;
        }

        public IEnumerable<string> descriptions => new List<string>()
        {
            "Compra del producto",
            "Venta del producto",
            "Vecimiento del producto",
            "Devolución del producto"
        };
    }
}

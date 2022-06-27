using MVVMGenericStructure.Services;
using System;
using System.Windows.Input;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class SalesChargeModalViewModel : ModalFormViewModel
    {
        public string titleBar { get; }

        private ICommand buyStockCommand;

        public SalesChargeModalViewModel(IMessenger _messenger, INavigationService closeModal) : base(closeModal)
        {
            _messenger.Subscribe<SaleChargeModalMessage>(this, SaleMessageSent);

            titleBar = "Cobrar la venta";
        }

        private void SaleMessageSent(object parameter)
        {
            var _parameter = (SaleChargeModalMessage)parameter;

            total = _parameter.total;
            buyStockCommand = _parameter.buyStockCommand;
        }

        private double _total;
        public double total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged(nameof(total));
            }
        }

        private double _payment;
        public double payment
        {
            get => _payment;
            set
            {
                _payment = value;

                errorsViewModel.ClearErrors(nameof(payment));

                if (_payment == 0)
                    errorsViewModel.AddError(nameof(payment), "Ingrese un pago");
                else if (_payment < 1)
                    errorsViewModel.AddError(nameof(payment), "Ingrese un pago positivo");
                else if (_payment < total)
                    errorsViewModel.AddError(nameof(payment), "Dinero insuficiente");

                OnPropertyChanged(nameof(payment));
                OnPropertyChanged(nameof(change));
            }
        }

        private double _change;
        public double change
        {
            get
            {
                _change = 0;

                errorsViewModel.ClearErrors(nameof(change));

                if (payment >= 0)
                    _change = payment - total;

                if (_change < 0)
                {
                    _change *= -1;
                    errorsViewModel.AddError(nameof(change), "Dinero insuficiente \nFaltan " + Math.Round(_change,2) + " córdobas.");
                }

                return _change;
            }
            set { }
        }

        public ICommand saveSale => new RelayCommand(o =>
        {
            buyStockCommand.Execute(null);
            exitCommand.Execute(null);
        });

        private void ResetProperties()
        {
            _change = 0;
            payment = 0;
        }

        public ICommand netPaymentCommand => new RelayCommand(parameter =>
        {
            payment = (bool)parameter ? total : 0;
        });

        public override void Dispose()
        {
            ResetProperties();
            base.Dispose();
        }
    }
}

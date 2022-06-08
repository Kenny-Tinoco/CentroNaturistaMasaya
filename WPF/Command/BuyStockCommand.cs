using Domain.Services;
using MVVMGenericStructure.Commands;
using System;
using System.Threading.Tasks;
using WPF.ViewModel;
using WPF.ViewsComponent.Utilities;

namespace WPF.Command
{
    public class BuyStockCommand : AsyncCommandBase
    {
        private readonly ProductSaleViewModel _saleViewModel;
        private readonly IBuyStockService _buyStockServices;

        public BuyStockCommand(ProductSaleViewModel saleViewModel, IBuyStockService buyStockServices)
        {
            _saleViewModel = saleViewModel;
            _buyStockServices = buyStockServices;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _saleViewModel.statusMessage = string.Empty;

            try
            {
                await _buyStockServices.BuyStock(_saleViewModel.employee, _saleViewModel.detailListing.ToEnumerable(), _saleViewModel.discount);
                _saleViewModel.Reset();
                _saleViewModel.statusMessage = "Venta existosa.";
            }
            catch (Exception)
            {
                _saleViewModel.statusMessage = "Falló la transacción.\n Intente de nuevo";
            }
        }
    }
}

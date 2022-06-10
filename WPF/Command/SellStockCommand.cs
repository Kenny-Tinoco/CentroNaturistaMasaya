using Domain.Entities;
using Domain.Services.TransactionServices;
using MVVMGenericStructure.Commands;
using System;
using System.Threading.Tasks;
using WPF.ViewModel;
using WPF.ViewModel.Utilities;

namespace WPF.Command
{
    public class SellStockCommand : AsyncCommandBase
    {
        private readonly ProductSaleViewModel _saleViewModel;
        private readonly ISellStockService _sellStockServices;

        public SellStockCommand(ProductSaleViewModel saleViewModel, ISellStockService sellStockServices)
        {
            _saleViewModel = saleViewModel;
            _sellStockServices = sellStockServices;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _saleViewModel.statusMessage = string.Empty;

            try
            {
                await _sellStockServices
                    .SellStock
                    (
                        _saleViewModel.employee.IdEmployee, 
                        _saleViewModel.detailListing.ToEnumerable<SaleDetail>(), 
                        _saleViewModel.discount
                    );

                _saleViewModel.Reset();
                _saleViewModel.statusMessage = "Venta existosa.";
            }
            catch (Exception)
            {
                _saleViewModel.statusMessage = "Falló la venta.\n Intente de nuevo";
            }
        }
    }
}

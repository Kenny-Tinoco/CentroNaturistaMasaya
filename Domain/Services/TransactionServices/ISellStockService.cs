using Domain.Entities;

namespace Domain.Services.TransactionServices
{
    public interface ISellStockService
    {
        Task SellStock(int idEmployee, IEnumerable<SaleDetail> detial, double discount);
    }
}

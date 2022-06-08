using Domain.Entities;

namespace Domain.Services
{
    public interface IBuyStockService
    {
        Task BuyStock(Employee employee, IEnumerable<SaleDetail> detial, double discount);
        double GetTotal(IEnumerable<SaleDetail> detail, double discount);
    }
}

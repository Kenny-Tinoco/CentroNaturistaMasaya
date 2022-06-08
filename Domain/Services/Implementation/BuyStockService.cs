using Domain.DAO;
using Domain.Entities;

namespace Domain.Services.Implementation
{
    public class BuyStockService : IBuyStockService
    {
        private readonly SellDAO sellDAO;

        public BuyStockService(SellDAO _sellDAO)
        {
            sellDAO = _sellDAO;
        }

        public async Task BuyStock(Employee employee, IEnumerable<SaleDetail> detial, double discount)
        {
            Sell element = new()
            {
                IdEmployee = employee.IdEmployee,
                Date = DateTime.Now,
                Discount = discount
            };

            element.Total = GetTotal(detial, discount);

            element.SaleDetails = detial.ToList();

            await sellDAO.Create(element);
        }

        public double GetTotal(IEnumerable<SaleDetail> detail, double discount)
        {
            double total = 0;

            foreach (var item in detail)
                total += item.Total;

            return total *= (1 - discount);
        }
    }
}

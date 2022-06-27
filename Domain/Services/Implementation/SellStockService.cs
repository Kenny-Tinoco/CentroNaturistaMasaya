using Domain.DAO;
using Domain.Entities;
using Domain.Services.TransactionServices;
using Domain.Utilities;

namespace Domain.Services.Implementation
{
    public class SellStockService : ISellStockService
    {
        private readonly SaleDAO sellDAO;

        public SellStockService(SaleDAO _sellDAO)
        {
            sellDAO = _sellDAO;
        }

        public async Task SellStock(int idEmployee, IEnumerable<SaleDetail> detial, double discount)
        {
            Sale element = new()
            {
                IdEmployee = idEmployee,
                Date = DateTime.Now,
                Discount = discount
            };

            element.Total = detial.GetTotal(discount);

            element.SaleDetails = detial.ToList();

            await sellDAO.Create(element);
        }
    }
}

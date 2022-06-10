using Domain.DAO;
using Domain.Entities;
using Domain.Services.TransactionServices;
using Domain.Utilities;

namespace Domain.Services.Implementation
{
    public class BuyStockService : IBuyStockService
    {
        private readonly SupplyDAO supplyDAO;

        public BuyStockService(SupplyDAO supplyDAO)
        {
            this.supplyDAO = supplyDAO;
        }

        public async Task BuyStock(int idProvider, IEnumerable<SupplyDetail> detail, double discount)
        {
            Supply element = new()
            {
                IdProvider = idProvider,
                Date = DateTime.Now,
                Discount = discount
            };

            element.Total = detail.GetTotal(discount);

            element.SupplyDetails = detail.ToList();

            await supplyDAO.Create(element);
        }
    }
}

using Domain.Entities;
using System.Diagnostics.Contracts;

namespace Domain.Logic
{
    public class StockPost
    {
        private Stock _stock;


        public StockPost()
        {
        }


        public void associateStockToProduct(Product productDTO)
        {
            Contract.Requires(productDTO != null);
            stock.IdProduct = productDTO.IdProduct;
        }

        public Stock stock
        {
            get
            {
                return _stock;
            }
            set
            {
                Contract.Requires(value != null);
                _stock = value;
            }
        }

        public double price
        {
            get
            {
                return stock.Price;
            }

            set
            {
                Contract.Requires(value >= 0);
                stock.Price = value;
            }
        }
        public void reduceQuantity()
        {
            if (stock.Quantity > 0)
                stock.Quantity--;
        }

        public void increaseQuantity()
        {
            stock.Quantity++;
        }
    }
}

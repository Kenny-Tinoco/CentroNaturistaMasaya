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
            stock.idProduct = productDTO.idProduct;
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
                return stock.price;
            }

            set
            {
                Contract.Requires(value >= 0);
                stock.price = value;
            }
        }
        public void reduceQuantity()
        {
            if (stock.quantity > 0)
                stock.quantity--;
        }

        public void increaseQuantity()
        {
            stock.quantity++;
        }
    }
}

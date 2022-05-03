using Domain.Entities;

namespace Domain.Logic
{
    public class Detail
    {
        private TransactionDetail entity;

        public Detail()
        {
            entity = new TransactionDetail();
        }

        public Detail(TransactionDetail entity)
        {
            this.entity = entity;
        }

        public Detail(Transaction transaction, Stock stock, int quantity): this()
        {
            initializeDetail(transaction, stock, quantity);
        }
        
        public void initializeDetail(Transaction transaction, Stock stock, int quantity)
        {
            entity.idTransaction = transaction.idTransaction;
            entity.idStock = stock.idStock;
            entity.price = stock.price;
            entity.quantity = quantity;
            calculateTotal();
        }

        public double total => entity.total;
        public void calculateTotal()
        {
            entity.total = entity.price * entity.quantity;
        }

        public void editQuantity(int quantity)
        {
            entity.quantity = quantity;
            calculateTotal();
        }
        public bool isThisDetail(int parameter)
        {
            return entity.idStock == parameter;
        }
    }
}
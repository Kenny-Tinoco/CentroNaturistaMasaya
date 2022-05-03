using Domain.Entities;
using System.Diagnostics.Contracts;

namespace Domain.Logic
{
    public abstract class TransactionLogic
    {
        protected Transaction transaction { get; set; }
        public List<Detail> details { get; set; }

        public TransactionLogic() : this(new Transaction())
        {
        }

        public TransactionLogic(Transaction parameter)
        {
            Contract.Requires(parameter != null);
            transaction = parameter;
            details = new List<Detail>();   
        }


        public void addDetail(Stock parameter, int quantity)
        {
            Contract.Requires(parameter != null && quantity >= 1);

            var element = new Detail(transaction, parameter, quantity);

            details.Add(element);
        }

        public void removeDetail(Stock parameter)
        {
            var element = findDetailByStockId(parameter.idStock);
            details.Remove(element);
        }

        public void editDetail(Stock parameter, int quantity)
        {
            var element = findDetailByStockId(parameter.idProduct);
            element.editQuantity(quantity);
        }

        public Detail findDetail(Stock parameter)
        {
            return findDetailByStockId(parameter.idStock);
        }


        protected virtual void makeTransaction()
        {
        }

        public void calculateTotal()
        {
            transaction.total = 0;

            foreach (var item in details)
            {
                transaction.total += item.total;
            }
        }

        private Detail? findDetailByStockId(int parameter)
        {
            Contract.Requires(parameter >= 0);

            return details.Find(x => x.isThisDetail(parameter));
        }

    }
}

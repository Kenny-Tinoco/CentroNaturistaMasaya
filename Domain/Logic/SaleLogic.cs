using System.Diagnostics.Contracts;
using System.Transactions;

namespace Domain.Logic
{
    public class SaleLogic : TransactionLogic
    {

        public void makeSale()
        {
            makeTransaction();
        }

        void reduceQuantityInProducts()
        {
        }
    }
}

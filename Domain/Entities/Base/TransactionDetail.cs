namespace Domain.Entities
{
    public class TransactionDetail : BaseEntity
    {
        public TransactionDetail()
        {
        }

        protected int IdDetail { get; set; }
        protected int IdTransaction { get; set; }
        public int IdStock { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}
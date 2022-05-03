namespace Domain.Entities
{
    public class TransactionDetail : BaseEntity
    {
        public int idTransactionDetail { get; set; }
        public int idTransaction { get; set; }
        public int idStock { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double total { get; set; }
    }
}

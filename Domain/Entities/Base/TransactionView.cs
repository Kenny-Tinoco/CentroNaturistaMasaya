namespace Domain.Entities.Views
{
    public class TransactionView : BaseEntity
    {
        protected int IdTransaction { get; set; }
        protected int IdElement { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
    }
}
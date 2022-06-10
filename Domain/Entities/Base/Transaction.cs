namespace Domain.Entities
{
    public class Transaction : BaseEntity
    {
        protected int IdTransaction { get; set; }
        protected int IdElement { get; set; }
        public DateTime Date { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
    }
}

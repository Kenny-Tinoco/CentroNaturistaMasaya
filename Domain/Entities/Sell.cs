namespace Domain.Entities
{
    public partial class Sell : BaseEntity
    {
        public Sell()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int IdSell { get; set; }
        public int IdEmployee { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}

namespace Domain.Entities
{
    public partial class Sell : BaseEntity
    {
        public int IdSell { get; set; }
        public int IdEmployee { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
    }
}

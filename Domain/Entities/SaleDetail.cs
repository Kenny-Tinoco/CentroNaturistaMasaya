namespace Domain.Entities
{
    public partial class SaleDetail : BaseEntity
    {
        public int IdSaleDetail { get; set; }
        public int IdSell { get; set; }
        public int IdStock { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}

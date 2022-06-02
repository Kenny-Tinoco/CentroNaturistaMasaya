namespace Domain.Entities.Views
{
    public partial class SaleDetailView : BaseEntity
    {
        public int IdSaleDetail { get; set; }
        public int IdSell { get; set; }
        public int IdStock { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public string Presentation { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}

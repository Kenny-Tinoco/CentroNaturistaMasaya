namespace Domain.Entities.Views
{
    public partial class SupplyDetailView : BaseEntity
    {
        public int IdSupplyDetail { get; set; }
        public int IdStock { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public string Presentation { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}

namespace Domain.Entities.Views
{
    public partial class SupplyDetailView : BaseEntity
    {
        public int idSupplyDetail { get; set; }
        public int idStock { get; set; }
        public string productName { get; set; } = null!;
        public string? productDescription { get; set; }
        public string presentation { get; set; } = null!;
        public int quantity { get; set; }
        public double price { get; set; }
        public double total { get; set; }
    }
}

namespace Domain.Entities.Views
{
    public partial class StockView : BaseEntity
    {
        public int idStock { get; set; }
        public string name { get; set; } = null!;
        public string? description { get; set; }
        public string presentation { get; set; } = null!;
        public double price { get; set; }
        public int quantity { get; set; }
        public string? entryDate { get; set; }
        public string? expiration { get; set; }
    }
}

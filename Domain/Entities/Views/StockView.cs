namespace Domain.Entities.Views
{
    public partial class StockView : BaseEntity
    {
        public int IdStock { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Presentation { get; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? Expiration { get; set; }
        public bool Status { get; set; }
        public byte[] Image { get; set; } = null!;
    }
}

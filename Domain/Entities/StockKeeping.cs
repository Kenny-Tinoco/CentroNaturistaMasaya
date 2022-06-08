namespace Domain.Entities
{
    public partial class StockKeeping : BaseEntity
    {
        public int IdStockKeeping { get; set; }
        public int IdStock { get; set; }
        public int? Quantity { get; set; }
        public bool? Concept { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}

namespace Domain.Entities.Views
{
    public partial class SupplyView : BaseEntity
    {
        public int IdSupply { get; set; }
        public int IdProvider { get; set; }
        public string ProviderName { get; set; } = null!;
        public DateTime Date { get; set; }
        public double Total { get; set; }
    }
}

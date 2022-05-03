namespace Domain.Entities.Views
{
    public partial class SupplyView : BaseEntity
    {
        public int idSupply { get; set; }
        public int idProvider { get; set; }
        public string providerName { get; set; } = null!;
        public string? date { get; set; }
        public double total { get; set; }
    }
}

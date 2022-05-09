namespace Domain.Entities
{
    public partial class SupplyDetail : BaseEntity
    {
        public int IdSupplyDetail { get; set; }
        public int IdSupply { get; set; }
        public int IdStock { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }

        public virtual Stock IdStockNavigation { get; set; } = null!;
        public virtual Supply IdSupplyNavigation { get; set; } = null!;
    }
}

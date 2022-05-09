namespace Domain.Entities
{
    public partial class Supply : BaseEntity
    {
        public Supply()
        {
            SupplyDetails = new HashSet<SupplyDetail>();
        }

        public int IdSupply { get; set; }
        public int IdProvider { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }

        public virtual Provider IdProviderNavigation { get; set; } = null!;
        public virtual ICollection<SupplyDetail> SupplyDetails { get; set; }
    }
}

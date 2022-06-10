namespace Domain.Entities
{
    public partial class Supply : Transaction
    {
        public Supply()
        {
            SupplyDetails = new HashSet<SupplyDetail>();
        }

        public int IdSupply
        {
            get => IdTransaction;
            set => IdTransaction = value;
        }

        public int IdProvider 
        { 
            get => IdElement; 
            set => IdElement = value; 
        }

        public virtual Provider IdProviderNavigation { get; set; } = null!;
        public virtual IEnumerable<SupplyDetail> SupplyDetails { get; set; }
    }
}

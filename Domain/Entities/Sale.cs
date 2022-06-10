namespace Domain.Entities
{
    public partial class Sale : Transaction
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }
        public int IdSale 
        { 
            get => IdTransaction;
            set => IdTransaction = value; 
        }

        public int IdEmployee 
        { 
            get => IdElement;
            set => IdElement = value; 
        }

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
        public virtual IEnumerable<SaleDetail> SaleDetails { get; set; }
    }
}

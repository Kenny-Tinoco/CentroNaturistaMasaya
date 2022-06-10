namespace Domain.Entities
{
    public partial class SupplyDetail : TransactionDetail
    {
        public int IdSupplyDetail
        {
            get => IdDetail;
            set => IdDetail = value;
        }

        public int IdSupply 
        { 
            get => IdTransaction; 
            set => IdTransaction = value; 
        }

        public virtual Supply IdSupplyNavigation { get; set; } = null!;
    }
}

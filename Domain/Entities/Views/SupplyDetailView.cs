namespace Domain.Entities.Views
{
    public partial class SupplyDetailView : TransactionDetailView
    {
        public int IdSupplyDetail 
        { 
            get => IdDetial;
            set => IdDetial = value; 
        }

        public int IdSupply
        {
            get => IdTransaction; 
            set => IdTransaction = value; 
        }
    }
}

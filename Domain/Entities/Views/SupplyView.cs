namespace Domain.Entities.Views
{
    public partial class SupplyView : TransactionView
    {
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
    }
}

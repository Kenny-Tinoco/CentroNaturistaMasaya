namespace Domain.Entities.Views
{
    public partial class SaleDetailView : TransactionDetailView
    {
        public int IdSaleDetail
        {
            get => IdDetial;
            set => IdDetial = value;
        }

        public int IdSale
        {
            get => IdTransaction;
            set => IdTransaction = value;
        }
    }
}

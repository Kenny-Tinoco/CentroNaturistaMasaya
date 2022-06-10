namespace Domain.Entities
{
    public partial class SaleDetail : TransactionDetail
    {
        public int IdSaleDetail
        { 
            get => IdDetail; 
            set => IdDetail = value; 
        }

        public int IdSale
        {
            get => IdTransaction;
            set => IdTransaction = value;
        }

        public virtual Sale IdSellNavigation { get; set; } = null!;
    }
}

namespace Domain.Entities.Views
{
    public partial class SaleView : TransactionView
    {
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
    }
}

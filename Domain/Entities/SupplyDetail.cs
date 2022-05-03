namespace Domain.Entities
{
    public partial class SupplyDetail : TransactionDetail
    {
        public int IdSupplyDetail { get; set; }
        public int IdSupply { get; set; }
        public int IdStock { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}

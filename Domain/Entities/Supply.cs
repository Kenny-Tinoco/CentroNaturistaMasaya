namespace Domain.Entities
{
    public partial class Supply : BaseEntity
    {
        public int IdSupply { get; set; }
        public int IdProvider { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
    }
}

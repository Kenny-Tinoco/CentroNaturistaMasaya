namespace Domain.Entities
{
    public partial class Stock : BaseEntity
    {
        public int idStock { get; set; }
        public int idProduct { get; set; }
        public int idPresentation { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public DateTime? entryDate { get; set; }
        public DateTime? expiration { get; set; }
    }
}

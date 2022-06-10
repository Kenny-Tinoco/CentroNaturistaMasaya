namespace Domain.Entities
{
    public partial class Stock : BaseEntity
    {

        public int IdStock { get; set; }
        public int IdProduct { get; set; }
        public int IdPresentation { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? Expiration { get; set; }
        public bool Status { get; set; }
        public byte[] Image { get; set; } = null!;

        public virtual Presentation? PresentationNavigation { get; set; }
        public virtual Product? ProductNavigation { get; set; }
    }
}

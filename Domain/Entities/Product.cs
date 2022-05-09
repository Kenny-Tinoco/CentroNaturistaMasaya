namespace Domain.Entities
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            PrescriptionProducts = new HashSet<PrescriptionProduct>();
            Stocks = new HashSet<Stock>();
        }

        public int IdProduct { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<PrescriptionProduct> PrescriptionProducts { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}

namespace Domain.Entities
{
    public partial class Presentation : BaseEntity
    {
        public Presentation()
        {
            Stocks = new HashSet<Stock>();
        }

        public int IdPresentation { get; set; }
        public string Name { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}

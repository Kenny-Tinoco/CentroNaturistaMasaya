namespace Domain.Entities
{
    public partial class Provider : BaseEntity
    {
        public Provider()
        {
            ProviderPhones = new HashSet<ProviderPhone>();
            Supplies = new HashSet<Supply>();
        }

        public int IdProvider { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string Ruc { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<ProviderPhone> ProviderPhones { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}

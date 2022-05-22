namespace Domain.Entities
{
    public partial class ProviderPhone : BaseEntity
    {
        public int IdProviderPhone { get; set; }
        public int IdProvider { get; set; }
        public string? Phone { get; set; }

        public virtual Provider ProviderNavigation{ get; set; } = null!;
    }
}

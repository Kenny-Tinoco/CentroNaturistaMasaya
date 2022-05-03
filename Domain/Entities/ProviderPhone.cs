namespace Domain.Entities
{
    public partial class ProviderPhone : BaseEntity
    {
        public int idProviderPhone { get; set; }
        public int idProvider { get; set; }
        public string? phone { get; set; }
    }
}

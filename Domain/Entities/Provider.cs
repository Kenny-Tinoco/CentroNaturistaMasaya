namespace Domain.Entities
{
    public partial class Provider : BaseEntity
    {
        public int idProvider { get; set; }
        public string name { get; set; } = null!;
        public string? address { get; set; }
        public string ruc { get; set; } = null!;
    }
}

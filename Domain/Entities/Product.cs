namespace Domain.Entities
{
    public partial class Product : BaseEntity
    {
        public int idProduct { get; set; }
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public int quantity { get; set; }
    }
}

namespace Domain.Entities
{
    public partial class Employee : BaseEntity
    {
        public int idEmployee { get; set; }
        public string name { get; set; } = null!;
        public string? lastName { get; set; }
        public string? address { get; set; }
    }
}

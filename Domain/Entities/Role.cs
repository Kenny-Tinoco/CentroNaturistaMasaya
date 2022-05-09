namespace Domain.Entities
{
    public partial class Role : BaseEntity
    {
        public int IdRole { get; set; }
        public string Name { get; set; } = null!;
    }
}

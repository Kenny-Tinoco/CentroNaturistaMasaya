namespace Domain.Entities
{
    public partial class Patient : BaseEntity
    {
        public int idPatient { get; set; }
        public string name { get; set; } = null!;
        public string? lastName { get; set; }
        public string? address { get; set; }
        public int age { get; set; }
    }
}

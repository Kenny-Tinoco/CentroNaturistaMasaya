namespace Domain.Entities
{
    public partial class Patient : BaseEntity
    {
        public Patient()
        {
            Consults = new HashSet<Consult>();
        }

        public int IdPatient { get; set; }
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Consult> Consults { get; set; }
    }
}

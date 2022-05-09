namespace Domain.Entities
{
    public partial class Consult : BaseEntity
    {
        public Consult()
        {
            PrescriptionProducts = new HashSet<PrescriptionProduct>();
        }

        public int IdConsult { get; set; }
        public int IdEmployee { get; set; }
        public int IdPatient { get; set; }
        public string? Symptom { get; set; }
        public DateTime Date { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
        public virtual Patient IdPatientNavigation { get; set; } = null!;
        public virtual ICollection<PrescriptionProduct> PrescriptionProducts { get; set; }
    }
}

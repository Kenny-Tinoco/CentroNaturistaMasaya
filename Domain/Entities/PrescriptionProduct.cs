namespace Domain.Entities
{
    public partial class PrescriptionProduct : BaseEntity
    {
        public int IdPrescriptionProduct { get; set; }
        public int IdConsult { get; set; }
        public int IdProduct { get; set; }

        public virtual Consult IdConsultNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}

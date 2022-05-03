namespace Domain.Entities
{
    public partial class PrescriptionProduct : BaseEntity
    {
        public int idPrescriptionProduct { get; set; }
        public int idConsult { get; set; }
        public int idProduct { get; set; }
    }
}

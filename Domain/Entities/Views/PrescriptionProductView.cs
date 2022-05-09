namespace Domain.Entities.Views
{
    public partial class PrescriptionProductView : BaseEntity
    {
        public int IdPrescriptionProduct { get; set; }
        public int IdProduct { get; set; }
        public string ProductName { get; set; } = null!;
    }
}

namespace Domain.Entities.Views
{
    public partial class ConsultView : BaseEntity
    {
        public int IdConsult { get; set; }
        public int IdPatient { get; set; }
        public string? PatientName { get; set; }
        public int IdEmployee { get; set; }
        public string? EmployeeName { get; set; }
        public string? Symptom { get; set; }
        public DateTime Date { get; set; }
    }
}

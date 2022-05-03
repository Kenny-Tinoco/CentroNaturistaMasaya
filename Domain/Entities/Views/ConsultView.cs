namespace Domain.Entities.Views
{
    public partial class ConsultView : BaseEntity
    {
        public int idConsult { get; set; }
        public int idPatient { get; set; }
        public string? patientName { get; set; }
        public int idEmployee { get; set; }
        public string? employeeName { get; set; }
        public string? symptom { get; set; }
        public string? date { get; set; }
    }
}

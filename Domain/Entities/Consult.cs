namespace Domain.Entities
{
    public partial class Consult : BaseEntity
    {
        public int idConsult { get; set; }
        public int idEmployee { get; set; }
        public int idPatient { get; set; }
        public string? symptom { get; set; }
        public DateTime date { get; set; }
    }
}

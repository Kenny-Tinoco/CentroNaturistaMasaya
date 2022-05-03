namespace Domain.Entities
{
    public partial class Account : BaseEntity
    {
        public int idAccount { get; set; }
        public int idEmployee { get; set; }
        public string userName { get; set; } = null!;
        public string password { get; set; } = null!;
        public DateTime? created { get; set; }
    }
}

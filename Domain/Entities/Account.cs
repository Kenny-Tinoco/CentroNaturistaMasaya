namespace Domain.Entities
{
    public partial class Account : BaseEntity
    {
        public int IdAccount { get; set; }
        public int IdEmployee { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? Created { get; set; }

        public virtual Employee EmployeeNavigation { get; set; } = null!;
    }
}

namespace Domain.Entities
{
    public partial class Employee : BaseEntity
    {
        public Employee()
        {
            Accounts = new HashSet<Account>();
            Consults = new HashSet<Consult>();
            Sells = new HashSet<Sale>();
        }

        public int IdEmployee { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Address { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Consult> Consults { get; set; }
        public virtual ICollection<Sale> Sells { get; set; }
    }
}

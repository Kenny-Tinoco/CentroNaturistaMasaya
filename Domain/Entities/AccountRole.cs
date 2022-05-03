namespace Domain.Entities
{
    public partial class AccountRole : BaseEntity
    {
        public int idRole { get; set; }
        public int idAccount { get; set; }
    }
}

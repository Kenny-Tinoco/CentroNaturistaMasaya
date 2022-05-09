namespace Domain.Entities
{
    public partial class AccountRole : BaseEntity
    {
        public int IdRole { get; set; }
        public int IdAccount { get; set; }

        public virtual Account IdAccountNavigation { get; set; } = null!;
        public virtual Role IdRoleNavigation { get; set; } = null!;
    }
}

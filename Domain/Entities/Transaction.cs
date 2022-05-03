namespace Domain.Entities
{
    public class Transaction : BaseEntity
    {
        internal object details;

        public int idTransaction { get; set; }
        public int idRelatedObjet { get; set; }
        public DateTime date { get; set; }
        public double total { get; set; }
    }
}

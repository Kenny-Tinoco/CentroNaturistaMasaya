namespace Domain.Entities.Views
{
    public partial class SellView : BaseEntity
    {
        public int idSell { get; set; }
        public int idEmployee { get; set; }
        public string? name { get; set; }
        public string? date { get; set; }
        public double total { get; set; }
    }
}

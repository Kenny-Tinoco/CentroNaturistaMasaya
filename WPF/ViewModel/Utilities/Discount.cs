namespace WPF.ViewModel.Utilities
{
    public class Discount
    {
        public Discount()
        {
        }
        public Discount(double discount, string name)
        {
            this.discount = discount;
            this.name = name;
        }

        public double discount { get; }
        public string name { get; }
    }
}

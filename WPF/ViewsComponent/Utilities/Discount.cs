namespace WPF.ViewModel
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

        public double discount { get; set; }
        public string name { get; set; }
    }
}

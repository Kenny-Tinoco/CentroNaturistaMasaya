using System.Windows.Controls;

namespace WPF.View.SaleModule
{
    public partial class ProductSalePage : Page
    {
        public ProductSalePage()
        {
            InitializeComponent();
        }

        private void DiscountsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            applyDiscountCheckBox.IsChecked = false;
            applyDiscountCheckBox.Command.Execute(applyDiscountCheckBox.IsChecked);
        }
    }
}

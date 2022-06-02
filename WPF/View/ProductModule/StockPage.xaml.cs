using System.Windows;
using System.Windows.Controls;

namespace WPF.View.ProductModule
{
    public partial class StockPage : Page
    {
        public StockPage()
        {
            InitializeComponent();
        }

        private void Expander_Process(object sender, RoutedEventArgs e)
        {
            if (sender is Expander expander)
            {
                var row = DataGridRow.GetRowContainingElement(expander);

                row.DetailsVisibility = expander.IsExpanded ? Visibility.Visible
                                                            : Visibility.Collapsed;
            }
        }
    }
}

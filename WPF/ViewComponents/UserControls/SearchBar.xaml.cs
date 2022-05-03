using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF.ViewComponents.UserControls
{
    public partial class SearchBar : UserControl
    {
        public string searchBarText
        {
            get { return (string)GetValue(searchBarTextProperty); }
            set { SetValue(searchBarTextProperty, value); }
        }

        public double BarWidth
        {
            get { return (double)GetValue(BarWidthProperty); }
            set { SetValue(BarWidthProperty, value); }
        }

        public double BarHeight
        {
            get { return (double)GetValue(BarHeightProperty); }
            set { SetValue(BarHeightProperty, value); }
        }



        public static readonly DependencyProperty BarWidthProperty =
            DependencyProperty.Register("BarWidth", typeof(double), typeof(SearchBar), new PropertyMetadata());

        public static readonly DependencyProperty BarHeightProperty =
            DependencyProperty.Register("BarHeight", typeof(double), typeof(SearchBar), new PropertyMetadata());

        public static readonly DependencyProperty searchBarTextProperty =
            DependencyProperty.Register("searchBarText", typeof(string), typeof(SearchBar), new PropertyMetadata(string.Empty));



        public SearchBar()
        {
            InitializeComponent();
        }

        private void searchText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchText.Text.Trim().Equals(""))
            {
                searchText.Text = "Búscar";
            }
        }

        private void searchText_GotFocus(object sender, RoutedEventArgs e)
        {
            if(searchText.Text == "Búscar")
            {
                searchText.Text = "";
            }
        }

        private void searchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchBarText = searchText.Text;
        }
    }
}

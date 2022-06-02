using System.Windows;
using System.Windows.Controls;

namespace WPF.ViewsComponent.UserControls
{
    public partial class SearchBar : UserControl
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SearchBar), new PropertyMetadata(string.Empty));


        public SearchBar()
        {
            InitializeComponent();
        }

        private void SearchText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchText.Text.Trim().Equals(""))
            {
                searchText.Text = "Búscar";
            }
        }

        private void SearchText_GotFocus(object sender, RoutedEventArgs e)
        {
            if(searchText.Text == "Búscar")
            {
                searchText.Text = "";
            }
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchText.Text.Trim().Equals("Búscar"))
                return;

            Text = searchText.Text;
        }
    }
}

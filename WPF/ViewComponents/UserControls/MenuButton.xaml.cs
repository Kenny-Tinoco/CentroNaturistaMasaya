using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF.ViewComponents.UserControls
{
    public partial class MenuButton : UserControl
    {
        public MenuButton()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public event RoutedEventHandler MenuButtonClick
        {
            add { AddHandler(MenuButtonClickEvent, value); }
            remove { RemoveHandler(MenuButtonClickEvent, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MenuButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(MenuButton), new PropertyMetadata());

        public static readonly RoutedEvent MenuButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(MenuButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MenuButton));

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MenuButtonClickEvent));
        }
    }
}

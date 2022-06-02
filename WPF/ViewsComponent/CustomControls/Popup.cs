using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF.ViewsComponent.CustomControls
{
    public class Popup : ContentControl
    {
        static Popup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Popup), new FrameworkPropertyMetadata(typeof(Popup)));
        }
        public string TitleBar
        {
            get { return (string)GetValue(TitleBarProperty); }
            set { SetValue(TitleBarProperty, value); }
        }

        public static readonly DependencyProperty TitleBarProperty =
            DependencyProperty.Register("TitleBar", typeof(string), typeof(Popup), new PropertyMetadata(string.Empty));

        public ImageSource IconBar
        {
            get { return (ImageSource)GetValue(IconBarProperty); }
            set { SetValue(IconBarProperty, value); }
        }

        public static readonly DependencyProperty IconBarProperty =
            DependencyProperty.Register("IconBar", typeof(ImageSource), typeof(Popup), new PropertyMetadata());

        public ICommand ExitCommand
        {
            get { return (ICommand)GetValue(ExitCommandProperty); }
            set { SetValue(ExitCommandProperty, value); }
        }

        public static readonly DependencyProperty ExitCommandProperty =
            DependencyProperty.Register("ExitCommand", typeof(ICommand), typeof(Popup), new PropertyMetadata());
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF.ViewsComponent.UserControls
{
    public partial class TitleBarButton : UserControl
    {
        public TitleBarButton()
        {
            InitializeComponent();
        }


        public object StyleButton
        {
            get { return (object)GetValue(StyleButtonProperty); }
            set { SetValue(StyleButtonProperty, value); }
        }

        public static readonly DependencyProperty StyleButtonProperty =
            DependencyProperty.Register("StyleButton", typeof(object), typeof(TitleBarButton), new PropertyMetadata());



        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(TitleBarButton), new PropertyMetadata());

        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(TitleBarButton), new PropertyMetadata());



        public object ButtonParameter
        {
            get { return (object)GetValue(ButtonParameterProperty); }
            set { SetValue(ButtonParameterProperty, value); }
        }

        public static readonly DependencyProperty ButtonParameterProperty =
            DependencyProperty.Register("ButtonParameter", typeof(object), typeof(TitleBarButton), new PropertyMetadata(string.Empty));


    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF.ViewComponents.UserControls
{
    public partial class TitleBarButton : UserControl
    {
        public TitleBarButton()
        {
            InitializeComponent();
        }


        public object styleButton
        {
            get { return (object)GetValue(styleButtonProperty); }
            set { SetValue(styleButtonProperty, value); }
        }

        public static readonly DependencyProperty styleButtonProperty =
            DependencyProperty.Register("styleButton", typeof(object), typeof(TitleBarButton), new PropertyMetadata());



        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(TitleBarButton), new PropertyMetadata());

        public ICommand buttonCommand
        {
            get { return (ICommand)GetValue(buttonCommandPropety); }
            set { SetValue(buttonCommandPropety, value); }
        }

        public static readonly DependencyProperty buttonCommandPropety =
            DependencyProperty.Register("buttonCommand", typeof(ICommand), typeof(TitleBarButton), new PropertyMetadata());



        public object buttonParameter
        {
            get { return (object)GetValue(buttonParameterProperty); }
            set { SetValue(buttonParameterProperty, value); }
        }

        public static readonly DependencyProperty buttonParameterProperty =
            DependencyProperty.Register("buttonParameter", typeof(object), typeof(TitleBarButton), new PropertyMetadata(string.Empty));


    }
}

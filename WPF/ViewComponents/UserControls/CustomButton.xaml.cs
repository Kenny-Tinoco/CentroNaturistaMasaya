using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF.ViewComponents.UserControls
{
    public partial class CustomButton : UserControl
    {
        public CustomButton()
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

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(CustomButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CustomButton), new PropertyMetadata());

        public ICommand buttonCommand
        {
            get { return (ICommand)GetValue(buttonCommandPropety); }
            set { SetValue(buttonCommandPropety, value); }
        }

        public static readonly DependencyProperty buttonCommandPropety =
            DependencyProperty.Register("buttonCommand", typeof(ICommand), typeof(CustomButton), new PropertyMetadata());


        public object buttonParameter
        {
            get { return (object)GetValue(buttonParameterProperty); }
            set { SetValue(buttonParameterProperty, value); }
        }

        public static readonly DependencyProperty buttonParameterProperty =
            DependencyProperty.Register("buttonParameter", typeof(object), typeof(CustomButton), new PropertyMetadata(string.Empty));

    }
}

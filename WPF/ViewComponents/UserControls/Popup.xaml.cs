using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF.ViewComponents.UserControls
{
    public partial class Popup : UserControl
    {
        public string titleBar
        {
            get { return (string)GetValue(titleBarProperty); }
            set { SetValue(titleBarProperty, value); }
        }

        public static readonly DependencyProperty titleBarProperty =
            DependencyProperty.Register("titleBar", typeof(string), typeof(Popup), new PropertyMetadata(string.Empty));

        public ImageSource iconBar
        {
            get { return (ImageSource)GetValue(iconBarProperty); }
            set { SetValue(iconBarProperty, value); }
        }

        public static readonly DependencyProperty iconBarProperty =
            DependencyProperty.Register("iconBar", typeof(ImageSource), typeof(Popup), new PropertyMetadata());

        public object popupContent
        {
            get { return (object)GetValue(popupContentProperty); }
            set { SetValue(popupContentProperty, value); }
        }

        public static readonly DependencyProperty popupContentProperty =
            DependencyProperty.Register("popupContent", typeof(object), typeof(Popup), new PropertyMetadata());

        public Popup()
        {
            InitializeComponent();
        }

        public ICommand buttonExitCommand
        {
            get { return (ICommand)GetValue(buttonExitCommandPropety); }
            set { SetValue(buttonExitCommandPropety, value); }
        }

        public static readonly DependencyProperty buttonExitCommandPropety =
            DependencyProperty.Register("buttonExitCommand", typeof(ICommand), typeof(Popup), new PropertyMetadata());

    }
}

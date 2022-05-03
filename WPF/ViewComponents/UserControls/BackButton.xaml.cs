using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF.ViewComponents.UserControls
{
    public partial class BackButton : UserControl
    {
        public BackButton()
        {
            InitializeComponent();
        }

        public ICommand buttonCommand
        {
            get { return (ICommand)GetValue(buttonCommandPropety); }
            set { SetValue(buttonCommandPropety, value); }
        }

        public static readonly DependencyProperty buttonCommandPropety =
            DependencyProperty.Register("buttonCommand", typeof(ICommand), typeof(BackButton), new PropertyMetadata());

    }
}

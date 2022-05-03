using System.Windows;
using System.Windows.Controls;

namespace WPF.ViewComponents.UserControls
{
    public partial class SpinBox : UserControl
    {

        public int value
        {
            get { return (int)GetValue(valueProperty); }
            set { SetValue(valueProperty, value); }
        }
        public static readonly DependencyProperty valueProperty =
            DependencyProperty.Register("value", typeof(int), typeof(SpinBox), new PropertyMetadata(0));
        public SpinBox()
        {
            InitializeComponent();
            spinBox.ValueChanged += new RoutedPropertyChangedEventHandler<double>(value_Changed);
            spinBox.Minimum = 0;
            spinBox.Maximum = 999;
            spinBox.SmallChange = 1;
        }

        private void value_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            value = (int)spinBox.Value;
        }
    }
}

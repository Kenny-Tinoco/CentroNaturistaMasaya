using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF.ViewsComponent.UserControls
{
    public partial class SpinBox : UserControl
    {
        public object value
        {
            get => GetValue(valueProperty);
            set => SetValue(valueProperty, value);
        }

        public static readonly DependencyProperty valueProperty =
            DependencyProperty.Register("value", typeof(object), typeof(SpinBox), new PropertyMetadata(0));

        public SpinBox()
        {
            InitializeComponent();
            spinBox.Minimum = 0;
            spinBox.Maximum = 999;
            spinBox.SmallChange = 1;
        }

        public double spinBoxValue 
        { 
            get => Convert.ToDouble(value);
            set => this.value = value.ToString();
        }
    }
}

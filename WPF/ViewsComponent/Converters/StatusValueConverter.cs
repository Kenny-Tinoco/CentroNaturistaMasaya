using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF.ViewsComponent.Converters
{
    public class StatusValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool boolValue && boolValue ? "Activo" : "Inactivo";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace ReservoirCalculator.Converters
{
    public class ReservoirTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string reservoirType && parameter is string expectedType)
            {
                return reservoirType == expectedType ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

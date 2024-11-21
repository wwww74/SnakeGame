using System.Globalization;

namespace Snake.Converters
{
    public class BoolToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue) return boolValue ? true : false;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool enabled) return enabled == true;
            return false;
        }
    }
}

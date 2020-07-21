using System;
using System.Globalization;
using System.Windows.Data;

namespace HotelDashboard.WPFClient.Converters
{
    /// <summary>
    /// Конвертер индексов для коллекций.
    /// Для вывода в Content индекса начиная с 1
    /// </summary>
    class IndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

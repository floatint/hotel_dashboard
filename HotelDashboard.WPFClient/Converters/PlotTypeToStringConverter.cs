using HotelDashboard.WPFClient.Views.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HotelDashboard.WPFClient.Converters
{
    /// <summary>
    /// Конвертер PlotType -> string
    /// </summary>
    class PlotTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((PlotType)value) switch
            {
                PlotType.Column => "Столбцы",
                PlotType.Row => "Строки",
                PlotType.Pie => "Круговая",
                _ => null,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

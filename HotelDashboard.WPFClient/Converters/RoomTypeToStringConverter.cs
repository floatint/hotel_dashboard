using HotelDashboard.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace HotelDashboard.WPFClient.Converters
{
    /// <summary>
    /// Конвертер RoomType -> string
    /// </summary>
    class RoomTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((RoomType)value) switch
            {
                RoomType.Single => "Одноместная",
                RoomType.Double => "Двухместная",
                RoomType.Family => "Семейная",
                _ => "Одноместная",
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

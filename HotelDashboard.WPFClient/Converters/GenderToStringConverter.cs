using HotelDashboard.Data.Models.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HotelDashboard.WPFClient.Converters
{
    class GenderToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ClientGender)value) switch
            {
                ClientGender.Male => "Мужской",
                ClientGender.Female => "Женский",
                _ => "Мужской",
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

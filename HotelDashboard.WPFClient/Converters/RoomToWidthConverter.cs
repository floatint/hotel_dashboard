using HotelDashboard.Data.Models;
using HotelDashboard.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using HotelDashboard.Data.Models.Enums;

namespace HotelDashboard.WPFClient.Converters
{
    public class RoomToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            } else
            {
                RoomDto roomDto = value as RoomDto;
                switch (roomDto.Type)
                {
                    case RoomType.Single:
                        return 50;
                    case RoomType.Double:
                        return 100;
                    case RoomType.Family:
                        return 200;
                    default:
                        return 50;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

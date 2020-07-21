using HotelDashboard.Data.Models.Enums;
using HotelDashboard.Services.DtoModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HotelDashboard.WPFClient.Converters
{
    /// <summary>
    /// Конвертер RoomDto -> ширина элемента комнаты
    /// </summary>
    public class RoomToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Application.Current.Resources["DefaultRoomWidth"];
            }
            else
            {
                RoomDto roomDto = value as RoomDto;
                switch (roomDto.Type)
                {
                    case RoomType.Single:
                        return Application.Current.Resources["SingleRoomWidth"];
                    case RoomType.Double:
                        return Application.Current.Resources["DoubleRoomWidth"];
                    case RoomType.Family:
                        return Application.Current.Resources["FamilyRoomWidth"];
                    default:
                        return Application.Current.Resources["DefaultRoomWidth"];
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

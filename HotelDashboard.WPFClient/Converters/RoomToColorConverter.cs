using HotelDashboard.Services.DtoModels;
using HotelDashboard.Services.DtoModels.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HotelDashboard.WPFClient.Converters
{
    /// <summary>
    /// Конвертер цвета для комнат
    /// </summary>
    public class RoomToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Application.Current.Resources["DefaultRoomBrush"];
            RoomDto roomDto = value as RoomDto;
            switch (roomDto.State)
            {
                case RoomState.Free:
                    return Application.Current.Resources["FreeRoomBrush"];
                case RoomState.Reserved:
                    return Application.Current.Resources["ReservedRoomBrush"];
                case RoomState.Populated:
                    return Application.Current.Resources["PopulatedRoomBrush"];
                default:
                    return Application.Current.Resources["DefaultRoomBrush"];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

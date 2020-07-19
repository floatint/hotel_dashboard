using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using HotelDashboard.Services.DtoModels.Enums;
using System.Windows.Media;

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
                return new SolidColorBrush(Colors.Gray);
            RoomDto roomDto = value as RoomDto;
            switch (roomDto.State)
            {
                case RoomState.Free:
                    return new SolidColorBrush(Colors.Green);
                case RoomState.Reserved:
                    return new SolidColorBrush(Colors.Yellow);
                case RoomState.Populated:
                    return new SolidColorBrush(Colors.Red);
                default:
                    return new SolidColorBrush(Colors.Green);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

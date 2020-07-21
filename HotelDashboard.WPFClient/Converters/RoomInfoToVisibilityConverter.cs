using HotelDashboard.Services.DtoModels;
using HotelDashboard.Services.DtoModels.Enums;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace HotelDashboard.WPFClient.Converters
{
    class RoomInfoToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            RoomState state = (RoomState)parameter;
            if (values == null || values[0] == null)
            {
                return Visibility.Collapsed;
            }
            else
            {
                RoomInfoDto roomInfoDto = values[0] as RoomInfoDto;
                switch (state)
                {
                    case RoomState.Free:
                        if (roomInfoDto.ReserveStart == default && roomInfoDto.ReserveEnd == default)
                        {
                            return Visibility.Visible;
                        }
                        else
                        {
                            return Visibility.Collapsed;
                        }
                    case RoomState.Reserved:
                        if (roomInfoDto.ReserveStart != default && roomInfoDto.ReserveEnd != default)
                        {
                            if (roomInfoDto.Clients == null || roomInfoDto.Clients.Count() == 0)
                            {
                                return Visibility.Visible;
                            }
                            else
                            {
                                return Visibility.Collapsed;
                            }
                        }
                        else
                        {
                            return Visibility.Collapsed;
                        }
                    case RoomState.Populated:
                        if (roomInfoDto.ReserveStart != default && roomInfoDto.ReserveEnd != default)
                        {
                            if (roomInfoDto.Clients != null && roomInfoDto.Clients.Count() != 0)
                            {
                                return Visibility.Visible;
                            }
                            else
                            {
                                return Visibility.Collapsed;
                            }
                        }
                        else
                        {
                            return Visibility.Collapsed;
                        }
                    default:
                        // по умолчанию не показываем
                        return Visibility.Collapsed;
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

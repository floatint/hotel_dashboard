﻿using HotelDashboard.Data.Models;
using HotelDashboard.Services.DtoModels;
using HotelDashboard.Services.DtoModels.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace HotelDashboard.WPFClient.Converters
{
    class RoomInfoToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            RoomState state = (RoomState)parameter;

            switch (state)
            {
                case RoomState.Free:
                    if (values[0] == null)
                    {
                        return Visibility.Collapsed;
                    }
                    else
                    {
                        RoomInfoDto roomInfoDto = values[0] as RoomInfoDto;
                        if (roomInfoDto.ReserveStart == default && roomInfoDto.ReserveEnd == default)
                        {
                            return Visibility.Visible;
                        }
                        else
                        {
                            return Visibility.Collapsed;
                        }
                    }
                case RoomState.Reserved:
                    if (values[0] == null)
                    {
                        return Visibility.Collapsed;
                    }
                    else
                    {
                        RoomInfoDto roomInfoDto = values[0] as RoomInfoDto;
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
                    }
                default:
                    // по умолчанию не показываем
                    return Visibility.Collapsed;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
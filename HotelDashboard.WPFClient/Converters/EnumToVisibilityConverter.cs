using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HotelDashboard.WPFClient.Converters
{
    /// <summary>
    /// Конвертер любого enum -> visibility
    /// </summary>
    class EnumToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return Visibility.Collapsed;
            }
            else
            {
                if (value.GetType() == parameter.GetType())
                {
                    if (value.Equals(parameter))
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
            //PlotType requiredPlotType = (PlotType)parameter;
            //if (value == null)
            //{
            //    return Visibility.Collapsed;
            //}
            //else
            //{
            //    PlotType plotType = (PlotType)
            //}
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

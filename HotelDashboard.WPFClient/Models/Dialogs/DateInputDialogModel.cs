using System;
using System.Windows;

namespace HotelDashboard.WPFClient.Models.Dialogs
{
    /// <summary>
    /// Модель диалога ввода дат
    /// </summary>
    class DateInputDialogModel
    {

        /// <summary>
        /// Валидация дат
        /// </summary>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        public bool IsValid(DateTime startDate, DateTime endDate)
        {
            if (startDate.CompareTo(DateTime.Now.Date) < 0)
            {
                return false;
            }
            else
            {
                if (startDate.CompareTo(endDate) > 0)
                {
                    return false;
                }
                else
                {
                    // проверим, что конечная дата не больше чем на N месяцев от начальной даты
                    var maxDate = CalcPeriod(startDate);
                    if (endDate > maxDate)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public DateTime CalcPeriod(DateTime dateTime)
        {
            // выбираем кол-во месяцев из ресурсов
            object monthsCount = Application.Current.Resources["ReserveMonthsCount"];
            if (monthsCount == null)
            {
                // устанавливаем по умолчанию
                monthsCount = 3;
            }
            return dateTime.AddMonths((int)monthsCount);
        }
    }
}

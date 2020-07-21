using System;

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
                    return true;
                }
            }
        }
    }
}

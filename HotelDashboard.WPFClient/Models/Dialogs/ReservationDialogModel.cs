using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.WPFClient.Models.Dialogs
{
    /// <summary>
    /// Модель диалога резервирования
    /// </summary>
    class ReservationDialogModel
    {

        /// <summary>
        /// Валидация дат
        /// </summary>
        /// <param name="startDate">Дата резервирования</param>
        /// <param name="endDate">Дата окончания резервирования</param>
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

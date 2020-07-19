using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.WPFClient.ViewModels.Dialogs
{
    /// <summary>
    /// Интерфейс ViewModel для всех диалогов
    /// </summary>
    interface IDialogViewModel
    {
        /// <summary>
        /// Результат диалога
        /// </summary>
        object Result { get; }
    }
}

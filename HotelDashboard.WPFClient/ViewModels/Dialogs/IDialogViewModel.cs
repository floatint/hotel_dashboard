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
        string Title { set;  get; }
        /// <summary>
        /// Результат диалога
        /// </summary>
        object Result { get; }
    }
}

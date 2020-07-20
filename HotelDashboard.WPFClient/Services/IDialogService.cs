using HotelDashboard.WPFClient.ViewModels;
using HotelDashboard.WPFClient.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace HotelDashboard.WPFClient.Services
{
    /// <summary>
    /// Интерфейс сервисов диалогов
    /// </summary>
    interface IDialogService
    {
        /// <summary>
        /// Просто вывод сообщения пользователю
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="message">Сообщение</param>
        void ShowMessage(string title, string message);
        /// <summary>
        /// Вызывает диалог и отдает введенные пользователем данные
        /// </summary>
        /// <typeparam name="TView">Тип представления</typeparam>
        /// <typeparam name="TViewModel">Тип логики представления</typeparam>
        /// <param name="title">Заголовок</param>
        object InputDialog<TView, TViewModel>(string title, object[] data) where TViewModel : BaseViewModel, IDialogViewModel, new()
                                                            where TView : Window, new();
    }
}

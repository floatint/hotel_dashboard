using HotelDashboard.WPFClient.ViewModels;
using HotelDashboard.WPFClient.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace HotelDashboard.WPFClient.Services
{
    /// <summary>
    /// Реализация сервиса диалогов
    /// </summary>
    class DialogService : IDialogService
    {

        public object InputDialog<TView, TViewModel>(string title) where TViewModel : BaseViewModel, IDialogViewModel, new() 
                                                                   where TView : Window, new()
        {
            // создание представления и логики
            TViewModel viewModel = new TViewModel();
            TView view = new TView();
            // подключение логики
            view.DataContext = viewModel;
            // показываем диалог и возвращаем введенные данные
            view.ShowDialog();
            return viewModel.Result;
        }

        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }
    }
}

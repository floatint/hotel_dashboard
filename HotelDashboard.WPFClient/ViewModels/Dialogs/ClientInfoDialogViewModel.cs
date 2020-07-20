using HotelDashboard.Services.DtoModels;
using HotelDashboard.WPFClient.Models.Dialogs;
using HotelDashboard.WPFClient.Services;
using HotelDashboard.WPFClient.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HotelDashboard.WPFClient.ViewModels.Dialogs
{
    class ClientInfoDialogViewModel : BaseViewModel, IDialogViewModel
    {
        public object[] Data { set => throw new NotImplementedException(); get => throw new  NotImplementedException(); }
        public string Title
        {
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
            get
            {
                return _title;
            }
        }

        public NewClientDto ClientInfo
        {
            set
            {
                _result = value;
                OnPropertyChanged(nameof(ClientInfo));
            }
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// Команда формирования информации о пользователе.
        /// На вход передается объект класса Window для возможности закрытия
        /// </summary>
        public ICommand OnOkCommand => new BaseCommand((o) =>
        {
            ICollection<string> validationErrors = new List<string>();
            // если данные не прошли валидацию
            if (!_model.IsValid(ClientInfo, validationErrors))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Введены некорректные данные:");
                sb.AppendLine();
                foreach(var e in validationErrors)
                {
                    sb.AppendLine(e);
                }
                // устанавливаем флажок
                _isValid = false;
                // показываем пользователю
                _dialogService.ShowMessage("Ошибка", sb.ToString());
            } else
            {
                _isValid = true;
                // модель валидна, можно закрыть диалог
                ((Window)o).Close();
            }
        });

        public object Result => _isValid ? _result : null;

        public ClientInfoDialogViewModel()
        {
            // устанавливаем дату рождения по умолчанию
            ClientInfo.Birthday = DateTime.Now.Date;
            OnPropertyChanged(nameof(ClientInfo));
        }

        private bool _isValid; // для правильной работы диалога
        private string _title;
        private NewClientDto _result = new NewClientDto();
        private readonly IDialogService _dialogService = new DialogService();
        private readonly ClientInfoDialogModel _model = new ClientInfoDialogModel();
    }
}

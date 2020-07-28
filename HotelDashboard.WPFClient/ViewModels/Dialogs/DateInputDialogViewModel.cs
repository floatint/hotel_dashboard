using HotelDashboard.Services.DtoModels;
using HotelDashboard.WPFClient.Models.Dialogs;
using HotelDashboard.WPFClient.Services;
using HotelDashboard.WPFClient.ViewModels.Commands;
using System;
using System.Windows;

namespace HotelDashboard.WPFClient.ViewModels.Dialogs
{
    /// <summary>
    /// ViewModel диалога резервирования комнаты
    /// </summary>
    class DateInputDialogViewModel : BaseViewModel, IDialogViewModel
    {
        public object Result => _dialogResult;

        public object[] Data
        {
            set
            {
                // если в диалог не были переданы заголовки для полей ввода
                if (value == null || value.Length < 2)
                {
                    throw new ArgumentException($"Неверное свойство {nameof(Data)} для диалога {nameof(DateInputDialogViewModel)}");
                }
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
            get
            {
                return _data;
            }
        }

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

        public string StartDateTitle
        {
            get
            {
                return Data[0].ToString();
            }
        }

        public string EndDateTitle
        {
            get
            {
                return Data[1].ToString();
            }
        }


        public DateTime StartDate
        {
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                // заполняем конечную дату
                EndDate = _startDate;
            }
            get
            {
                return _startDate;
            }
        }

        /// <summary>
        /// Выбранная конечная дата
        /// </summary>
        public DateTime EndDate
        {
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                // устанавливаем диапозон конечной даты
                // просто вызываем OnPropertyChanged
                SecondDisplayDateStart = value;
                SecondDisplayDateEnd = value;
            }
            get
            {
                return _endDate;
            }
        }
        /// <summary>
        /// DisplayDateStart для начальной даты
        /// </summary>
        public DateTime FirstDisplayDateStart
        {
            get
            {
                return DateTime.Now.Date;
            }
        }

        /// <summary>
        /// DisplayDateEnd для начальной даты
        /// </summary>
        public DateTime FirstDisplayDateEnd
        {
            get
            {
                // получим период резервирования
                return _model.CalcPeriod(DateTime.Now.Date);
            }
        }

        /// <summary>
        /// DisplayDateStart для даты окончания
        /// </summary>
        public DateTime SecondDisplayDateStart
        {
            set
            {
                OnPropertyChanged(nameof(SecondDisplayDateStart));
            }
            get
            {
                // просто вернем конечную дату
                return EndDate;
            }
        }

        /// <summary>
        /// DisplayDateEnd для даты окончания
        /// </summary>
        public DateTime SecondDisplayDateEnd
        {
            set
            {
                OnPropertyChanged(nameof(SecondDisplayDateEnd));
            }
            get
            {
                // пересчитываем период
                return _model.CalcPeriod(EndDate);
            }
        }


        /// <summary>
        /// Подтверждение резервирования. На вход должен получить класс Window, чтобы закрыть диалог.
        /// </summary>
        public BaseCommand OnSaveCommand => new BaseCommand((o) =>
        {
            if (_model.IsValid(_startDate, _endDate))
            {
                _dialogResult = new ReserveDataDto
                {
                    ReserveStart = StartDate.Date,
                    ReserveEnd = EndDate.Date
                };
            }
            else
            {
                _dialogService.ShowMessage("Ошибка", "Введите корректные даты");
                return;
            }
            // закрываем диалог
            ((Window)o).Close();
        });

        public DateInputDialogViewModel()
        {
            _model = new DateInputDialogModel();
            _dialogService = new DialogService();

            // установим начальные значения
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date;
        }

        private DateTime _startDate;
        private DateTime _endDate;
        private DateInputDialogModel _model;
        private IDialogService _dialogService;
        private ReserveDataDto _dialogResult;
        private string _title;
        private object[] _data;
    }
}

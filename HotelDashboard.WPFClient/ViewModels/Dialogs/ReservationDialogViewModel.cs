﻿using HotelDashboard.Services.DtoModels;
using HotelDashboard.WPFClient.Models;
using HotelDashboard.WPFClient.Services;
using HotelDashboard.WPFClient.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Text;
using System.Windows;

namespace HotelDashboard.WPFClient.ViewModels.Dialogs
{
    /// <summary>
    /// ViewModel диалога резервирования комнаты
    /// </summary>
    class ReservationDialogViewModel : BaseViewModel, IDialogViewModel
    {
        public object Result => _dialogResult;


        public DateTime StartDate
        {
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
            get
            {
                return _startDate;
            }
        }

        public DateTime EndDate
        {
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
            get
            {
                return _endDate;
            }
        }

        /// <summary>
        /// Подтверждение резервирования
        /// </summary>
        public BaseCommand OnOkCommand { get; }

        public ReservationDialogViewModel()
        {
            _model = new ReservationDialogModel();
            _dialogService = new DialogService();

            // установим начальные значения
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date;
            
            // инициализируем логику 

            OnOkCommand = new BaseCommand((o) =>
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
                    _dialogService.ShowMessage("Ошибка", "Введите корректные даты резервирования");
                    return;
                }
                // закрываем диалог
                ((Window)o).Close();
            });
        }

        private DateTime _startDate;
        private DateTime _endDate;
        private ReservationDialogModel _model;
        private IDialogService _dialogService;
        private object _dialogResult;
    }
}

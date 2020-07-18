using HotelDashboard.Data.Models;
using HotelDashboard.Services.DtoModels;
using HotelDashboard.WPFClient.Data;
using HotelDashboard.WPFClient.Models;
using HotelDashboard.WPFClient.ViewModels.Commands;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HotelDashboard.WPFClient.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<CorpsDto> Coprs
        {

            get
            {
                return _model.GetCorps();
            }
        }

        //TODO: тут нужно вызывать onpropertychanged
        public ObservableCollection<FloorDto> Floors
        {
            set
            {
                _floors = value;
                OnPropertyChanged(nameof(Floors));
            }
            get
            {
                return _floors;
            }
        }

        public ObservableCollection<RoomDto> Rooms
        {
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(Rooms));
            }
            get
            {
                return _rooms;
            }
        }

        /// <summary>
        /// Комманда выбора корпуса
        /// </summary>
        public BaseCommand OnSelectCorps { get; }

        /// <summary>
        /// Комманда выбора этажа
        /// </summary>
        public BaseCommand OnSelectFloor { get; }

        /// <summary>
        /// Комманда выбора комнаты
        /// </summary>
        public BaseCommand OnSelectRoom { get; }


        public MainViewModel()
        {
            OnSelectCorps = new BaseCommand(o =>
            {
                Floors = _model.GetCorpsFloors((CorpsDto)o);
                var a = 0;
            });

            OnSelectFloor = new BaseCommand(o =>
            {
                Rooms = _model.GetFloorRooms((FloorDto)o);
            });

            OnSelectRoom = new BaseCommand(o =>
            {
                var a = 9;
            });
        }

        private readonly MainModel _model = new MainModel();
        private ObservableCollection<CorpsDto> _coprs;
        private ObservableCollection<FloorDto> _floors;
        private ObservableCollection<RoomDto> _rooms;
    }
}

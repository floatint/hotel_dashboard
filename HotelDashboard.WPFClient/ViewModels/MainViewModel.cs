using HotelDashboard.Data.Models;
using HotelDashboard.Services.DtoModels;
using HotelDashboard.WPFClient.Data;
using HotelDashboard.WPFClient.Models;
using HotelDashboard.WPFClient.Services;
using HotelDashboard.WPFClient.ViewModels.Commands;
using HotelDashboard.WPFClient.ViewModels.Dialogs;
using HotelDashboard.WPFClient.Views.Dialogs;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HotelDashboard.Services.DtoModels.Enums;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace HotelDashboard.WPFClient.ViewModels
{
    class MainViewModel : BaseViewModel
    {

        /// <summary>
        /// Корпусы
        /// </summary>
        public ObservableCollection<CorpsDto> Coprs
        {

            get
            {
                return _model.GetCorps();
            }
        }

        /// <summary>
        /// Этажи
        /// </summary>
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

        /// <summary>
        /// Комнаты
        /// </summary>
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
        /// Выбранная комната
        /// </summary>
        public RoomDto SelectedRoom
        {
            set
            {
                _selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom));
                // подгружаем подробную информацию о комнате, если комната != null
                if (_selectedRoom != null)
                {
                    SelectedRoomInfo = _model.GetRoomInfo(SelectedRoom);
                }
                else
                {
                    SelectedRoomInfo = null;
                }
            }
            get
            {
                return _selectedRoom;
            }
        }

        /// <summary>
        /// Подробная информация для выбранной комнаты
        /// </summary>
        public RoomInfoDto SelectedRoomInfo
        {
            set
            {
                _selectedRoomInfo = value;
                OnPropertyChanged(nameof(SelectedRoomInfo));
            }
            get
            {
                return _selectedRoomInfo;
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

        /// <summary>
        /// Комманда резервирования комнаты
        /// </summary>
        public BaseCommand OnRoomReservation { get; }

        /// <summary>
        /// Комманда заселения комнаты
        /// </summary>
        public BaseCommand OnRoomPopulation { get; }
        /// <summary>
        /// Комманда освобождения комнаты
        /// </summary>
        public BaseCommand OnRoomFree  => new BaseCommand((_) => {
            // пытаемся освободить комнату
            try
            {
                _model.FreeRoom(SelectedRoom);
            }
            catch(Exception ex)
            {
                _dialogService.ShowMessage("Ошибка", ex.ToString());
                return;
            }
            // обновляем статус на клиентской стороне
            _selectedRoom.State = RoomState.Free;
            _selectedRoomInfo = new RoomInfoDto();
            // просим ui перерисовать
            CollectionViewSource.GetDefaultView(Rooms).Refresh();
            OnPropertyChanged(nameof(SelectedRoom));
            OnPropertyChanged(nameof(SelectedRoomInfo));
            
        });

        public MainViewModel()
        {
            // инициализация сервиса диалогов
            _dialogService = new DialogService();

            // иницализация логики

            OnSelectCorps = new BaseCommand(o =>
            {
                SelectedRoom = null;
                Floors = _model.GetCorpsFloors((CorpsDto)o);
            });

            OnSelectFloor = new BaseCommand(o =>
            {
                SelectedRoom = null;
                Rooms = _model.GetFloorRooms((FloorDto)o);
            });

            OnSelectRoom = new BaseCommand(o =>
            {
                SelectedRoom = (RoomDto)o;
            });

            OnRoomReservation = new BaseCommand((_) =>
            {
                // показываем диалог резервирования
                object result = _dialogService.InputDialog<ReservationDialogView, ReservationDialogViewModel>("Резерви");
                if (result != null)
                {
                    // обращаемся к модели
                    try
                    {
                        _model.ReserveRoom(_selectedRoom, (ReserveDataDto)result);
                    }
                    catch(Exception ex)
                    {
                        _dialogService.ShowMessage("Ошибка", ex.ToString());
                        return;
                    }
                    // успешно зарезервировали, обновляем свойства на клиентской стороне
                    _selectedRoom.State = RoomState.Reserved;
                    // т.к. RoomDto не отслеживает INotifyPropertyChanged, то приходится использовать это
                    CollectionViewSource.GetDefaultView(Rooms).Refresh();
                    // заполним информацию о текущей выбранной комнате
                    ReserveDataDto reserveDataDto = result as ReserveDataDto;
                    _selectedRoomInfo.ReserveStart = reserveDataDto.ReserveStart;
                    _selectedRoomInfo.ReserveEnd = reserveDataDto.ReserveEnd;
                    // просим обновить UI
                    OnPropertyChanged(nameof(SelectedRoomInfo));
                }
            });

            OnRoomPopulation = new BaseCommand((_) =>
            {

            });
        }

        private readonly MainModel _model = new MainModel();
        private IDialogService _dialogService;
        private ObservableCollection<FloorDto> _floors;
        private ObservableCollection<RoomDto> _rooms;
        private RoomDto _selectedRoom;
        private RoomInfoDto _selectedRoomInfo;
    }
}

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
                try
                {
                    return _model.GetCorps();
                }catch(Exception ex)
                {
                    _dialogService.ShowMessage("Ошибка", ex.ToString());
                }
                // по умолчанию
                return null;
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
                    try
                    {
                        SelectedRoomInfo = _model.GetRoomInfo(SelectedRoom);
                    }catch(Exception ex)
                    {
                        _dialogService.ShowMessage("Ошибка", ex.ToString());
                    }
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
        public BaseCommand OnSelectCorps => new BaseCommand(o => {
            SelectedRoom = null;
            Rooms = null;
            try
            {
                Floors = _model.GetCorpsFloors((CorpsDto)o);
            }catch(Exception ex)
            {
                _dialogService.ShowMessage("Ошибка", ex.ToString());
            }
        });

        /// <summary>
        /// Комманда выбора этажа
        /// </summary>
        public BaseCommand OnSelectFloor => new BaseCommand(o =>
        {
            SelectedRoom = null;
            try
            {
                Rooms = _model.GetFloorRooms((FloorDto)o);
            } catch(Exception ex)
            {
                _dialogService.ShowMessage("Ошибка", ex.ToString());
            }
        });

        /// <summary>
        /// Комманда выбора комнаты
        /// </summary>
        public BaseCommand OnSelectRoom => new BaseCommand(o =>
        {
            SelectedRoom = (RoomDto)o;
        });

        /// <summary>
        /// Комманда резервирования комнаты
        /// </summary>
        public BaseCommand OnRoomReservation => new BaseCommand((_) =>
        {
            // объявляем надписи диалога
            object[] fieldTitles = new object[2] { "Дата резервирования:", "Дата окончания резервирования:" };
            // пытаемся получить данные для резервирования
            ReserveDataDto result = null;
            try
            {
                result = (ReserveDataDto)_dialogService.InputDialog<DateInputDialogView, DateInputDialogViewModel>("Резервирование", fieldTitles);
            }catch(Exception ex)
            {
                // нет смысла писать всю информацию
                _dialogService.ShowMessage("Ошибка", ex.Message);
                return;
            }

            // если данных введены
            if (result != null)
            {
                // обращаемся к модели
                try
                {
                    _model.ReserveRoom(_selectedRoom, (ReserveDataDto)result);
                }
                catch (Exception ex)
                {
                    // нужна вся информация
                    _dialogService.ShowMessage("Ошибка", ex.ToString());
                    return;
                }
                // успешно зарезервировали, обновляем свойства на клиентской стороне
                _selectedRoom.State = RoomState.Reserved;
                // т.к. RoomDto не отслеживает INotifyPropertyChanged, то приходится использовать это
                CollectionViewSource.GetDefaultView(Rooms).Refresh();
                // заполним информацию о текущей выбранной комнате
                _selectedRoomInfo.ReserveStart = result.ReserveStart;
                _selectedRoomInfo.ReserveEnd = result.ReserveEnd;
                // просим обновить UI
                OnPropertyChanged(nameof(SelectedRoomInfo));
            }
        });

        /// <summary>
        /// Комманда заселения комнаты
        /// </summary>
        public BaseCommand OnRoomPopulation => new BaseCommand((_) => {

            // данные о времени проживания
            ReserveDataDto reserveDataDto = null;
            // клиенты
            List<NewClientDto> clients = new List<NewClientDto>();

            // надписи для полей ввода
            object[] fieldTitles = new object[] { "Дата заселения:", "Дата окончания проживания:" };
            // пробуем получить время проживания
            try
            {
                reserveDataDto = (ReserveDataDto)_dialogService.InputDialog<DateInputDialogView, DateInputDialogViewModel>("Период проживания", fieldTitles);
            }
            catch(Exception ex)
            {
                _dialogService.ShowMessage("Ошибка", ex.Message);
                return;
            }

            // если данные введены
            if (reserveDataDto != null)
            {
                // начинаем ввод клиентов
                // пытаемся заполнить всю комнату
                for (int i = 1; i <= (int)SelectedRoom.Type; i++)
                {
                    string title = string.Format("Информация о клиенте №{0}", i);
                    NewClientDto clientDto = (NewClientDto)_dialogService.InputDialog<ClientInfoDialogView, ClientInfoDialogViewModel>(title, null);
                    if (clientDto != null)
                    {
                        clients.Add(clientDto);
                    }
                    else
                    {
                        // если пользователь не захотел вводить, то заканчиваем
                        break;
                    }
                }

                // смотрим, сколько клиентов ввели
                if (clients.Count != 0)
                {
                    // формируем данные для отправки в модель
                    PopulationDto populationDto = new PopulationDto
                    {
                        Clients = new ClientsEnumerableDto {
                            ClientsEnumerable = clients.AsEnumerable()
                        },
                        ReserveData = reserveDataDto
                    };
                    // отправляем
                    try
                    {
                        _model.PopulateRoom(SelectedRoom, populationDto);
                    }
                    catch (Exception ex)
                    {
                        _dialogService.ShowMessage("Ошибка", ex.ToString());
                        return;
                    }

                    // если отправка прошла успешно, то обновляем клиентскую часть
                    _selectedRoom.State = RoomState.Populated;
                    CollectionViewSource.GetDefaultView(Rooms).Refresh();
                    // попробуем перезагрузить информацию о комнате
                    try
                    {
                        SelectedRoomInfo = _model.GetRoomInfo(SelectedRoom);
                    } catch(Exception ex)
                    {
                        _dialogService.ShowMessage("Ошибка", ex.ToString());
                    }
                }
                else
                {
                    // просто выйдем
                    return;
                }
            }
            else
            {
                // просто выйдем
                return;
            }
        });

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
        }

        private readonly MainModel _model = new MainModel();
        private IDialogService _dialogService;
        private ObservableCollection<FloorDto> _floors;
        private ObservableCollection<RoomDto> _rooms;
        private RoomDto _selectedRoom;
        private RoomInfoDto _selectedRoomInfo;
    }
}

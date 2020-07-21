using HotelDashboard.Services.DtoModels;
using HotelDashboard.WPFClient.Data;
using System.Collections.ObjectModel;

namespace HotelDashboard.WPFClient.Models
{
    /// <summary>
    /// Модель управления
    /// </summary>
    public class ControlModel
    {

        /// <summary>
        /// Получить корпусы гостинницы
        /// </summary>
        public ObservableCollection<CorpsDto> GetCorps()
        {
            return new ObservableCollection<CorpsDto>(_hotelProvider.GetAllCorps<CorpsDto>());
        }

        /// <summary>
        /// Получить этажи заданного корпуса
        /// </summary>
        /// <param name="corpsDto">Информация о корпусе</param>
        public ObservableCollection<FloorDto> GetCorpsFloors(CorpsDto corpsDto)
        {
            return new ObservableCollection<FloorDto>(_hotelProvider.GetCorpsFloors<FloorDto>(corpsDto.Id));
        }

        /// <summary>
        /// Получить комнаты на этаже
        /// </summary>
        /// <param name="floorDto">Информация об этаже</param>
        public ObservableCollection<RoomDto> GetFloorRooms(FloorDto floorDto)
        {
            return new ObservableCollection<RoomDto>(_hotelProvider.GetFloorRooms<RoomDto>(floorDto.Id));
        }

        /// <summary>
        /// Получить развернутую информацию о комнате
        /// </summary>
        /// <param name="roomDto">Базовая информация о комнате</param>
        /// <returns></returns>
        public RoomInfoDto GetRoomInfo(RoomDto roomDto)
        {
            return _hotelProvider.GetRoomInfo<RoomInfoDto>(roomDto.Id);
        }

        /// <summary>
        /// Зарезервировать комнату
        /// </summary>
        /// <param name="roomDto">DTO комнаты</param>
        /// <param name="reserveDataDto">Данные резервирования</param>
        public void ReserveRoom(RoomDto roomDto, ReserveDataDto reserveDataDto)
        {
            _hotelProvider.ReserveRoom(roomDto.Id, reserveDataDto);
        }

        /// <summary>
        /// Освободить комнату
        /// </summary>
        /// <param name="roomDto">DTO комнаты</param>
        public void FreeRoom(RoomDto roomDto)
        {
            _hotelProvider.FreeRoom(roomDto.Id);
        }

        /// <summary>
        /// Заселить комнату
        /// </summary>
        /// <param name="roomDto">DTO комнаты</param>
        /// <param name="populationDto">Информация для заселения</param>
        public void PopulateRoom(RoomDto roomDto, PopulationDto populationDto)
        {
            _hotelProvider.PopulateRoom(roomDto.Id, populationDto);
        }

        private readonly IHotelProvider _hotelProvider = new HotelWebApiProvider();
    }
}

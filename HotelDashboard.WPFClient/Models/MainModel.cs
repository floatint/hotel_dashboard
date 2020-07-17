using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using HotelDashboard.Data.Models;
using HotelDashboard.Services.DtoModels;
using HotelDashboard.Services.Services;
using HotelDashboard.WPFClient.Data;

namespace HotelDashboard.WPFClient.Models
{
    /// <summary>
    /// Модель главного окна
    /// </summary>
    public class MainModel
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
        /// <param name="corps">Информация о корпусе</param>
        public ObservableCollection<FloorDto> GetCorpsFloors(CorpsDto corps)
        {
            return new ObservableCollection<FloorDto>(_hotelProvider.GetCorpsFloors<FloorDto>(corps.Id));
        }

        public ObservableCollection<RoomDto> GetFloorRooms(FloorDto floor)
        {
            return new ObservableCollection<RoomDto>(_hotelProvider.GetFloorRooms<RoomDto>(floor.Id));
        }

        public MainModel()
        {
            _hotelProvider = new HotelWebApiProvider();
        }

        private readonly IHotelProvider _hotelProvider;
    }
}

using HotelDashboard.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HotelDashboard.WPFClient.Data
{
    /// <summary>
    /// Провайдер Web Api для сервера гостинницы
    /// </summary>
    class HotelWebApiProvider : IHotelProvider
    {
        public HotelWebApiProvider()
        {
            // получаем базовый адрес из ресурсов приложения
            object baseApiValue = (string)Application.Current.Resources["WebApiBaseURI"];
            // если в настройках не был указан базовый адрес API
            if (baseApiValue == null)
            {
                throw new Exception("Отстутствует адрес сервера");
            }
            else
            {
                // пытаемся создать URI объект
                if (!Uri.TryCreate((string)baseApiValue, UriKind.Absolute, out _baseApiUri))
                {
                    throw new Exception("Не удалось создать URI объект");
                };
                // создаем провайдер
                _httpProvider = new HTTPProvider();
            }
        }

        public IEnumerable<TCorpsDto> GetAllCorps<TCorpsDto>()
        {
            Uri allCorpsUri = new Uri(_baseApiUri, new Uri("api/corps/", UriKind.Relative));
            return _httpProvider.Get<IEnumerable<TCorpsDto>>(allCorpsUri);
        }

        public IEnumerable<TFloorDto> GetCorpsFloors<TFloorDto>(int corpsId)
        {
            Uri corpsFloors = new Uri(_baseApiUri, new Uri(string.Format("api/corps/{0}/floors", corpsId), UriKind.Relative));
            return _httpProvider.Get<IEnumerable<TFloorDto>>(corpsFloors);
        }

        public IEnumerable<TRoomDto> GetFloorRooms<TRoomDto>(int floorId)
        {
            Uri floorRooms = new Uri(_baseApiUri, new Uri(string.Format("api/floor/{0}/rooms", floorId), UriKind.Relative));
            return _httpProvider.Get<IEnumerable<TRoomDto>>(floorRooms);
        }

        public TRoomInfoDto GetRoomInfo<TRoomInfoDto>(int roomId)
        {
            Uri roomInfo = new Uri(_baseApiUri, new Uri(string.Format("api/room/{0}/info", roomId), UriKind.Relative));
            return _httpProvider.Get<TRoomInfoDto>(roomInfo);
        }

        public void ReserveRoom<TReservationData>(int roomId, TReservationData reservationData)
        {
            Uri reservationUri = new Uri(_baseApiUri, new Uri(string.Format("api/room/{0}/reserve", roomId), UriKind.Relative));
            _httpProvider.Update<TReservationData, object>(reservationUri, reservationData);
        }

        public void FreeRoom(int roomId)
        {
            Uri freeRoom = new Uri(_baseApiUri, new Uri(string.Format("api/room/{0}/free", roomId), UriKind.Relative));
            _httpProvider.Update<object, object>(freeRoom, null);
        }

        public void PopulateRoom<TPopulationData>(int roomId, TPopulationData populationData)
        {
            Uri populateRoom = new Uri(_baseApiUri, new Uri(string.Format("api/room/{0}/populate", roomId), UriKind.Relative));
            _httpProvider.Update<TPopulationData, object>(populateRoom, populationData);
        }

        public TStatisticsDto GetCorpsStatistics<TStatisticsDto>(int corpsId)
        {
            Uri corpsStatistics = new Uri(_baseApiUri, new Uri(string.Format("api/statistics/corps/{0}", corpsId), UriKind.Relative));
            return _httpProvider.Get<TStatisticsDto>(corpsStatistics);
        }

        public TStatisticsDto GetFloorStatistics<TStatisticsDto>(int floorId)
        {
            Uri floorStatistics = new Uri(_baseApiUri, new Uri(string.Format("api/statistics/floor/{0}", floorId), UriKind.Relative));
            return _httpProvider.Get<TStatisticsDto>(floorStatistics);
        }

        public TStatisticsDto GetRoomTypeStatistics<TStatisticsDto>(int floorId, RoomType roomType)
        {
            Uri roomTypeStatistics = new Uri(_baseApiUri, new Uri(string.Format("api/statistics/floor/{0}/roomtype/{1}", floorId, Enum.Format(typeof(RoomType), roomType, "d")), UriKind.Relative));
            return _httpProvider.Get<TStatisticsDto>(roomTypeStatistics);
        }

        // базовый адрес api
        private readonly Uri _baseApiUri;
        private readonly IDataProvider _httpProvider;
    }
}

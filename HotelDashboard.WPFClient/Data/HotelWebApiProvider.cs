using HotelDashboard.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;
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

        // базовый адрес api
        private readonly Uri _baseApiUri;
        private readonly IDataProvider _httpProvider;
    }
}

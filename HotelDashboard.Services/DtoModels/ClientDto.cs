using HotelDashboard.Data.Models;
using HotelDashboard.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Информация о клиенте
    /// </summary>
    public class ClientDto : BaseModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { set; get; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { set; get; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string LastName { set; get; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { set; get; }
        /// <summary>
        /// Пол
        /// </summary>
        public ClientGender Gender { set; get; }
        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string RegistrationAddress { set; get; }

    }
}

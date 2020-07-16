using HotelDashboard.Data.Models.Enums;
using System;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Информация о новом пользователе
    /// </summary>
    public class NewClient
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

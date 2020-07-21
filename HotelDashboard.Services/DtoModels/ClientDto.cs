using HotelDashboard.Data.Models;
using HotelDashboard.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Имя"), MinLength(1)]
        public string FirstName { set; get; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Фамилия"), MinLength(1)]
        public string SecondName { set; get; }
        /// <summary>
        /// Отчество
        /// </summary>
        [Required(ErrorMessage = "Отчество"), MinLength(1)]
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
        [Required(ErrorMessage = "Адрес регистрации"), MinLength(1)]
        public string RegistrationAddress { set; get; }

    }
}

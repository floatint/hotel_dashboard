using HotelDashboard.Data.Models.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Информация о новом пользователе
    /// </summary>
    public class NewClientDto
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Имя")]
        public string FirstName { set; get; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Фамилия")]
        public string SecondName { set; get; }
        /// <summary>
        /// Отчество
        /// </summary>
        [Required(ErrorMessage = "Отчество")]
        public string LastName { set; get; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        [Range(typeof(DateTime), "01/01/1900", "01/01/2100", ErrorMessage = "Дата рождения")]
        public DateTime Birthday { set; get; }
        /// <summary>
        /// Пол
        /// </summary>
        public ClientGender Gender { set; get; }
        /// <summary>
        /// Адрес регистрации
        /// </summary>
        [Required(ErrorMessage = "Адрес регистрации")]
        public string RegistrationAddress { set; get; }
    }
}

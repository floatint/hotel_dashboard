using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDashboard.Data.Models.Enums;

namespace HotelDashboard.Data.Models
{
    /// <summary>
    /// Модель клиента отеля
    /// </summary>
    public class Client : BaseModel
    {
        /// <summary>
        /// ID комнаты, где проживает клиент
        /// </summary>
        public int RoomId { set; get; }
        /// <summary>
        /// Комната
        /// </summary>
        public virtual Room Room { set; get; }
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

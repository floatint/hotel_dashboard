using System.Collections.Generic;

namespace HotelDashboard.Data.Models
{
    /// <summary>
    /// Модель корпуса гостинницы
    /// </summary>
    public class Corps : BaseModel
    {
        /// <summary>
        /// Этажи
        /// </summary>
        public virtual ICollection<Floor> Floors { set; get; }
    }
}

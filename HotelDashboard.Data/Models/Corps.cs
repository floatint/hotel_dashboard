using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

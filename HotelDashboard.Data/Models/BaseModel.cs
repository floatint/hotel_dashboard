using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Data.Models
{
    /// <summary>
    /// Базовая модель. Содержит общие поля для всех моделей. Например, ID
    /// </summary>
    public class BaseModel
    {
        public int Id { set; get; }
    }
}

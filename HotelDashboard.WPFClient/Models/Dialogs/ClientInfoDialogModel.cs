using HotelDashboard.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HotelDashboard.WPFClient.Models.Dialogs
{
    /// <summary>
    /// Модель диалога ввода информации о клиенте
    /// </summary>
    class ClientInfoDialogModel
    {
        /// <summary>
        /// Валидация данных клиента
        /// </summary>
        /// <param name="newClientDto">Данные клиента</param>
        public bool IsValid(NewClientDto newClientDto, ICollection<string> errors)
        {
            // ошибки валидации
            var results = new List<ValidationResult>();
            // контекст
            var context = new ValidationContext(newClientDto);
            // валидируем модель
            if (!Validator.TryValidateObject(newClientDto, context, results))
            {
                foreach(var r in results)
                {
                    errors.Add(r.ErrorMessage);
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

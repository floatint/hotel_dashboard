using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelDashboard.WPFClient.Data
{
    /// <summary>
    /// Интерфейс провайдера данных
    /// </summary>
    interface IDataProvider
    {
        /// <summary>
        /// Получить данные из источника по URI
        /// </summary>
        /// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
        /// <param name="uri">URI данных</param>
        TResult Get<TResult>(Uri uri);
        /// <summary>
        /// Отправить данные в хранилище по URI
        /// </summary>
        /// <typeparam name="TData">Тип отправляемых данных</typeparam>
        /// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
        /// <param name="uri">URI для отправки</param>
        /// <param name="data">Отправляемые данные</param>
        TResult Add<TData, TResult>(Uri uri, TData data);
        /// <summary>
        /// Обновить данные в источнике по URI
        /// </summary>
        /// <typeparam name="TData">Тип измененных данных</typeparam>
        /// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
        /// <param name="uri">URI для обновления</param>
        /// <param name="data">Измененные данные</param>
        TResult Update<TData, TResult>(Uri uri, TData data);
        /// <summary>
        /// Удалить данные из источника по URI
        /// </summary>
        /// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
        /// <param name="uri">URI для удаления</param>
        TResult Delete<TResult>(Uri uri);
    }
}

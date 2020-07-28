using HotelDashboard.WPFClient.Data.Contents;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HotelDashboard.WPFClient.Data
{
    class HTTPProvider : IDataProvider
    {
        public HTTPProvider()
        {
            _httpClient = new HttpClient();
            // настраиваем на работу с json
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// GET запрос
        /// </summary>
        /// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
        /// <param name="uri">URI для получения данных</param>
        public TResult Get<TResult>(Uri uri)
        {
            // запускаем таск на обращение к URI по HTTP
            Task<HttpResponseMessage> responseTask = Task.Run(() => _httpClient.GetAsync(uri));
            // ждем ответа и возвращаем полученные данные
            return FromResponse<TResult>(responseTask.Result);

        }

        /// <summary>
        /// POST запрос
        /// </summary>
        /// <typeparam name="TData">Тип отправляемых данных</typeparam>
        /// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
        /// <param name="uri">URI для отправления данных</param>
        /// <param name="data">Отправляемые данные</param>
        public TResult Add<TData, TResult>(Uri uri, TData data)
        {
            Task<HttpResponseMessage> responseTask = Task.Run(() => _httpClient.PostAsync(uri, new JsonContent(data)));
            return FromResponse<TResult>(responseTask.Result);
        }

        /// <summary>
        /// PUT запрос
        /// </summary>
        /// <typeparam name="TData">Тип обновляемых данных</typeparam>
        /// <typeparam name="TResult">Тип возвращаемых данных</typeparam>
        /// <param name="uri">URI для обновления</param>
        /// <param name="data">Обновляемые данные</param>
        public TResult Update<TData, TResult>(Uri uri, TData data)
        {
            Task<HttpResponseMessage> responseTask = Task.Run(() => _httpClient.PutAsync(uri, new JsonContent(data)));
            return FromResponse<TResult>(responseTask.Result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        public TResult Delete<TResult>(Uri uri)
        {
            Task<HttpResponseMessage> responseTask = Task.Run(() => _httpClient.DeleteAsync(uri));
            return FromResponse<TResult>(responseTask.Result);
        }

        /// <summary>
        /// Конвертер ответа сервера в объекты
        /// </summary>
        /// <typeparam name="TResult">Тип объекта</typeparam>
        /// <param name="response">Ответ сервера</param>
        private TResult FromResponse<TResult>(HttpResponseMessage response)
        {
            // если запрос был неудачный
            if (!response.IsSuccessStatusCode)
            {
                // формируем сообщение
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Не удалось получить данные");
                sb.Append("URI: ");
                sb.AppendLine(response.RequestMessage.RequestUri.ToString());
                sb.Append("Method: ");
                sb.AppendLine(response.RequestMessage.Method.ToString());
                sb.Append("Status: ");
                sb.Append(response.StatusCode);

                throw new Exception(sb.ToString());
            }
            else
            {
                // если успешно
                // запускаем таск на получение контента
                Task<string> contentTask = Task.Run(() => response.Content.ReadAsStringAsync());
                // ждем контент и отдаем объект
                return JsonConvert.DeserializeObject<TResult>(contentTask.Result);
            }
        }

        private HttpClient _httpClient;
    }
}

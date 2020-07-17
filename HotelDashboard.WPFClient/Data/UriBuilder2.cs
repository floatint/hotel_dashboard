using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.WPFClient.Data
{
    /// <summary>
    /// Билдер запросов
    /// </summary>
    class UriBuilder2
    {
        /// <summary>
        /// Итоговый URI
        /// </summary>
        public Uri Uri { private set;  get; }

        public UriBuilder2(Uri baseUri)
        {
            Uri = baseUri;
        }

        public UriBuilder2 Add(string relativePath)
        {
            Uri = new Uri(Uri, new Uri(relativePath, UriKind.Relative));
            return this;
        }
    }
}

using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Mime;
using System.Text;

namespace HotelDashboard.WPFClient.Data.Contents
{
    class JsonContent : StringContent
    {
        public JsonContent(object o)
            : base(JsonConvert.SerializeObject(o), Encoding.UTF8, MediaTypeNames.Application.Json)
        { }

    }
}

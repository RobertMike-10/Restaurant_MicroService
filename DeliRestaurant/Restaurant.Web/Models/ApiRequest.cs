using static Restaurant.Web.Constants;

namespace Restaurant.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public dynamic Data { get; set; }
        public string AccessToken { get; set; }


    } 
}

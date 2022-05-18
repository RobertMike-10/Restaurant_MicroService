using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;
using System.Text;

namespace Restaurant.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        private HttpMethod SelectApiMethod(Constants.ApiType apiType)
        {
            switch (apiType)
            {
                case Constants.ApiType.POST:
                    return HttpMethod.Post;                 
                case Constants.ApiType.PUT:
                    return HttpMethod.Put;                    
                case Constants.ApiType.GET:
                    return HttpMethod.Get;
                case Constants.ApiType.DELETE:
                    return HttpMethod.Delete;
                default:
                    return HttpMethod.Get;
            }
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("ReataurantApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), 
                        Encoding.UTF8,"application/json");

                }
                HttpResponseMessage apiResponse = null;

                message.Method = SelectApiMethod(apiRequest.ApiType);

                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto!;
            }
            catch(Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    isSuccess=false
                };
                var result = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(result);
                return apiResponseDto!;
            }
        }
    }
}

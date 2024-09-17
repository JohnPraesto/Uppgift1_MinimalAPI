using Library_MVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace Library_MVC.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get ; set; }
        public IHttpClientFactory _httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            responseModel = new ResponseDto();
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("Uppgift1_Library");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();

                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                } // UPPTÄCKER HÄR VID EDIT ATT BOOK ID ÄR 0, DET SKA DEN INTE VA JU?!

                HttpResponseMessage apiResponse = null;
                switch (apiRequest.Type)
                {
                    case StaticDetails.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case StaticDetails.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        break;
                }

                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync(); // här blir det fel fattas parameter int id
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent); // HÄR SER JAG VID EDIT ATT BOKEN FÅTT EN NY ID!!!
                return apiResponseDto;

            }
            catch (Exception e)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };

                var result = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(result);
                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }


    }
}

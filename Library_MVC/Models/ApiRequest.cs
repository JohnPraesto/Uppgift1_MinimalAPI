using static Library_MVC.StaticDetails;

namespace Library_MVC.Models
{
    public class ApiRequest // Vet inte vad som händer här heller.
    {
        public ApiType Type { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}

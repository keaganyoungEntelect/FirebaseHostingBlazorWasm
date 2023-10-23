using BlazorWasmSample.wwwroot.Data;
using Newtonsoft.Json;
using System.Text;

namespace BlazorWasmSample.Services
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, StringContent content);
    }

    public class HttpClientService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> PostAsync(string url,StringContent content)
        {
            return await _httpClient.PostAsync(url,content);
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _httpClient.GetAsync(url);
        }
    }

    public class FunkoService
    {
        private readonly IHttpService _httpService;

        public FunkoService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<FunkoPops>> GetFunkos(string apiUrl)
        {
            List<FunkoPops>? funkoList;

            var response = await _httpService.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                try
                {
                    var funkoDict = JsonConvert.DeserializeObject<Dictionary<string, FunkoPops>>(jsonResponse);

                    funkoList = funkoDict.Values.ToList();

                    return funkoList;
                }
                catch (JsonSerializationException)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public async Task<List<FunkoPops>> GetFunkosWishlist(string apiUrl)
        {
            List<FunkoPops>? funkoList = new List<FunkoPops>();
            var response = await _httpService.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var funkoDictionary = JsonConvert.DeserializeObject<Dictionary<string, FunkoPops>>(jsonResponse);

                if (funkoDictionary != null)
                {
                    funkoList = funkoDictionary.Values.ToList();
                    return funkoList;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<List<FunkoPops>> AddFunkoFromData(FunkoPops givenFunko,string url)
        {
                var jsonBody = System.Text.Json.JsonSerializer.Serialize(givenFunko);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Funko added successfully!");
                    List<FunkoPops>? funkoList = new List<FunkoPops>();
                    funkoList.Add(givenFunko);
                    return funkoList;

                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            
        }
    }
}

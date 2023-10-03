using BlazorWasmSample.wwwroot.Data;
using System.Text;
using Newtonsoft.Json;

namespace BlazorWasmSample.Services
{
    public class FunkoAPI
    {
        public async Task<List<FunkoPops>> GetFunkos()
        {
            string GetFunkosResponse;
            List<FunkoPops>? funkoList = new List<FunkoPops>();
            var apiUrl = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Funkos.json";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(apiUrl);

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
                    GetFunkosResponse = "No Funkos found.";
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
       
        public async Task AddFunkoFromData(FunkoPops givenFunko)
        {
            try
            {
                var apiUrl = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Funkos.json";

                var jsonBody = System.Text.Json.JsonSerializer.Serialize(givenFunko);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Funko added successfully!");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}

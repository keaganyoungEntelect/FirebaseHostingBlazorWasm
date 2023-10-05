using BlazorWasmSample.wwwroot.Data;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Http;
using Google.Api;
using System.ComponentModel;

namespace BlazorWasmSample.Services
{
    public class FunkoAPI
    {
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        public async Task<List<FunkoPops>> GetFunkos()
        {
            await CheckIDs();
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

        public async Task CheckIDs()
        {
            List<FunkoPops>? funkoList = new List<FunkoPops>();
            var apiUrl = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Funkos.json";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var funkoDictionary = JsonConvert.DeserializeObject<Dictionary<string, FunkoPops>>(jsonResponse);
                foreach(var funko in funkoDictionary)
                {
                    string ID = funko.Key;
                    if (funko.Value.Id != ID)
                    {
                        var apiUrlUpdate = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Funkos.json";
                        funko.Value.Id = ID;
                        apiUrlUpdate = apiUrlUpdate.Replace(".json", "/" + ID + ".json");
                        var jsonBody = System.Text.Json.JsonSerializer.Serialize(funko.Value);
                        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                        var post = await client.PutAsync(apiUrlUpdate, content);
                    }
                }
            }
        }

        public async Task RemoveFunko(FunkoPops funko)
        {

            List<FunkoPops>? funkoList = new List<FunkoPops>();
            var apiUrl = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Funkos/"+funko.Id+".json";
            HttpClient client = new HttpClient();

            if(funko.Id == null)
            {

            }
            else
            {
                try
                {
                    var response = await client.DeleteAsync(apiUrl);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}

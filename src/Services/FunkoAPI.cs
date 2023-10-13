using BlazorWasmSample.wwwroot.Data;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Http;
using Google.Api;
using System.ComponentModel;
using System;

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

        public async Task<List<FunkoPops>> GetFunkosWishlist()
        {
            await CheckIDsWishlist();
            List<FunkoPops>? funkoList = new List<FunkoPops>();
            var apiUrl = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Wishlist.json";
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

        public async Task AddFunkoToWishlist(FunkoPops givenFunko)
        {

            try
            {
                var apiUrl = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Wishlist.json";

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

        public async Task CheckIDsWishlist()
        {
            List<FunkoPops>? funkoList = new List<FunkoPops>();
            var apiUrl = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Wishlist.json";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var funkoDictionary = JsonConvert.DeserializeObject<Dictionary<string, FunkoPops>>(jsonResponse);
                foreach (var funko in funkoDictionary)
                {
                    string ID = funko.Key;
                    if (funko.Value.Id != ID)
                    {
                        var apiUrlUpdate = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Wishlist.json";
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

        public async Task RemoveFunkoWishlist(FunkoPops funko)
        {

            List<FunkoPops>? funkoList = new List<FunkoPops>();
            var apiUrl = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Wishlist/" + funko.Id + ".json";
            HttpClient client = new HttpClient();

            if (funko.Id == null)
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

        public async Task<List<string>> GetUser()
        {
            List<string>? userdetails = new List<string>();
            var apiUrl = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Users.json";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var userDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

                if (userDictionary != null)
                {
                    userdetails = userDictionary.Values.ToList();
                    return userdetails;
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

        public async Task<int?> UpdateFunkoData(FunkoPops updateFunko)
        {
            List<FunkoPops>? funkoList = new List<FunkoPops>();
            var apiUrl = "https://keagan-funkocollectionapp-default-rtdb.firebaseio.com/Funkos/" + updateFunko.Id + ".json";
            HttpClient client = new HttpClient();

            if (updateFunko.Id == null)
            {
                Console.WriteLine("Id is null");
                return 0;
            }
            else
            {
                try
                {
                    var jsonBody = System.Text.Json.JsonSerializer.Serialize(updateFunko);
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    await client.PutAsync(apiUrl,content);
                    return updateFunko.price;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return 0;
                }
            }
        }
    }
}

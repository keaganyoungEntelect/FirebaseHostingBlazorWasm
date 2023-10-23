using BlazorTest.Classes;
using BlazorWasmSample.Services;
using BlazorWasmSample.wwwroot.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Text;

namespace BlazorTest
{
    public class FunkoAPI_Tests
    {
        [SetUp]
        public void Setup()
        {

        }
       
        public class MockHttpService : IHttpService
        {
            public Task<HttpResponseMessage> GetAsync(string url)
            {
                var mockData = @"{
                    ""-Ng3JKFs4QkNtmxCKx8w"": {
                        ""Id"": ""-Ng3JKFs4QkNtmxCKx8w"",
                        ""handle"": ""aughra-age-of-resistance"",
                        ""imageName"": ""https://images.hobbydb.com/processed_uploads/catalog_item_photo/catalog_item_photo/image/740299/Aughra_%2528Age_of_Resistance%2529_Vinyl_Art_Toys_9089111a-adf6-4027-8cf2-494d30413bbd_large.jpg"",
                        ""price"": 350,
                        ""series"": [""Pop! Television"", ""Pop! Vinyl""],
                        ""title"": ""Aughra (Age of Resistance)""
                    },
                    ""-Ng3JP34Q4rqXb845OMu"": {
                        ""Id"": ""-Ng3JP34Q4rqXb845OMu"",
                        ""handle"": ""rian"",
                        ""imageName"": ""https://images.hobbydb.com/processed_uploads/catalog_item_photo/catalog_item_photo/image/740283/Rian_Vinyl_Art_Toys_2b246bee-a66a-4ea2-8b61-a3904426526e_large.jpg"",
                        ""price"": 300,
                        ""series"": [""Pop! Television"", ""Pop! Vinyl""],
                        ""title"": ""Rian""
                    }
                }";

                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(mockData, Encoding.UTF8, "application/json")
                };

                return Task.FromResult(response);
            }

            public Task<HttpResponseMessage> PostAsync(string url,StringContent content)
            {
                var mockData = @"{
                    ""-Ng3JKFs4QkNtmxCKx8w"": {
                        ""Id"": ""-Ng3JKFs4QkNtmxCKx8w"",
                        ""handle"": ""aughra-age-of-resistance"",
                        ""imageName"": ""https://images.hobbydb.com/processed_uploads/catalog_item_photo/catalog_item_photo/image/740299/Aughra_%2528Age_of_Resistance%2529_Vinyl_Art_Toys_9089111a-adf6-4027-8cf2-494d30413bbd_large.jpg"",
                        ""price"": 350,
                        ""series"": [""Pop! Television"", ""Pop! Vinyl""],
                        ""title"": ""Aughra (Age of Resistance)""
                    },
                    ""-Ng3JP34Q4rqXb845OMu"": {
                        ""Id"": ""-Ng3JP34Q4rqXb845OMu"",
                        ""handle"": ""rian"",
                        ""imageName"": ""https://images.hobbydb.com/processed_uploads/catalog_item_photo/catalog_item_photo/image/740283/Rian_Vinyl_Art_Toys_2b246bee-a66a-4ea2-8b61-a3904426526e_large.jpg"",
                        ""price"": 300,
                        ""series"": [""Pop! Television"", ""Pop! Vinyl""],
                        ""title"": ""Rian""
                    }
                }";

                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(mockData, Encoding.UTF8, "application/json")
                };

                return Task.FromResult(response);
            }
        }

        public class MockHttpServiceUnsuccessful : IHttpService
        {
            public Task<HttpResponseMessage> GetAsync(string url)
            {
                var mockData = @"{
                    ""-Ng3JKFs4QkNtmxCKx8w"": {
                        ""Id"": ""-Ng3JKFs4QkNtmxCKx8w"",
                        ""handle"": ""aughra-age-of-resistance"",
                        ""imageName"": ""https://images.hobbydb.com/processed_uploads/catalog_item_photo/catalog_item_photo/image/740299/Aughra_%2528Age_of_Resistance%2529_Vinyl_Art_Toys_9089111a-adf6-4027-8cf2-494d30413bbd_large.jpg"",
                        ""price"": 350,
                        ""series"": [""Pop! Television"", ""Pop! Vinyl""],
                        ""title"": ""Aughra (Age of Resistance)""
                    },
                    ""-Ng3JP34Q4rqXb845OMu"": {
                        ""Id"": ""-Ng3JP34Q4rqXb845OMu"",
                        ""handle"": ""rian"",
                        ""imageName"": ""https://images.hobbydb.com/processed_uploads/catalog_item_photo/catalog_item_photo/image/740283/Rian_Vinyl_Art_Toys_2b246bee-a66a-4ea2-8b61-a3904426526e_large.jpg"",
                        ""price"": 300,
                        ""series"": [""Pop! Television"", ""Pop! Vinyl""],
                        ""title"": ""Rian""
                    }
                }";

                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(mockData, Encoding.UTF8, "application/json")
                };

                return Task.FromResult(response);
            }
            public Task<HttpResponseMessage> PostAsync(string url, StringContent content)
            {
                var mockData = @"{
                    ""-Ng3JKFs4QkNtmxCKx8w"": {
                        ""Id"": ""-Ng3JKFs4QkNtmxCKx8w"",
                        ""handle"": ""aughra-age-of-resistance"",
                        ""imageName"": ""https://images.hobbydb.com/processed_uploads/catalog_item_photo/catalog_item_photo/image/740299/Aughra_%2528Age_of_Resistance%2529_Vinyl_Art_Toys_9089111a-adf6-4027-8cf2-494d30413bbd_large.jpg"",
                        ""price"": 350,
                        ""series"": [""Pop! Television"", ""Pop! Vinyl""],
                        ""title"": ""Aughra (Age of Resistance)""
                    },
                    ""-Ng3JP34Q4rqXb845OMu"": {
                        ""Id"": ""-Ng3JP34Q4rqXb845OMu"",
                        ""handle"": ""rian"",
                        ""imageName"": ""https://images.hobbydb.com/processed_uploads/catalog_item_photo/catalog_item_photo/image/740283/Rian_Vinyl_Art_Toys_2b246bee-a66a-4ea2-8b61-a3904426526e_large.jpg"",
                        ""price"": 300,
                        ""series"": [""Pop! Television"", ""Pop! Vinyl""],
                        ""title"": ""Rian""
                    }
                }";

                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(mockData, Encoding.UTF8, "application/json")
                };

                return Task.FromResult(response);
            }
        }

        //Tests for GetFunkos
        [Test]
        public async Task GetFunkos_ReturnNonNull_Test()
        {
            var mockHttpService = new MockHttpService();
            var funkoService = new FunkoService(mockHttpService);
            var mockUrl = "https://example.com";

            var result = await funkoService.GetFunkos(mockUrl);

            NUnit.Framework.Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetFunkos_ReturnListFunkos_Test()
        {
            var mockHttpService = new MockHttpService();
            var funkoService = new FunkoService(mockHttpService);
            var mockUrl = "https://example.com";

            var result = await funkoService.GetFunkos(mockUrl);

            NUnit.Framework.Assert.IsInstanceOf<List<FunkoPops>>(result);
        }

        [Test]
        public async Task GetFunkos_BadRequest_Test()
        {
            var mockHttpService = new MockHttpServiceUnsuccessful();
            var funkoService = new FunkoService(mockHttpService);
            var mockUrl = "https://example.com";

            var response = await funkoService.GetFunkos(mockUrl);

            NUnit.Framework.Assert.IsNull(response);
        }


        //Tests for GetFunkosWishlist
        [Test]
        public async Task GetFunkosWishlist_ReturnNonNull_Test()
        {
            var mockHttpService = new MockHttpService();
            var funkoService = new FunkoService(mockHttpService);
            var mockUrl = "https://example.com";

            var result = await funkoService.GetFunkosWishlist(mockUrl);

            NUnit.Framework.Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetFunkosWishlist_ReturnListFunkos_Test()
        {
            var mockHttpService = new MockHttpService();
            var funkoService = new FunkoService(mockHttpService);
            var mockUrl = "https://example.com";

            var result = await funkoService.GetFunkosWishlist(mockUrl);

            NUnit.Framework.Assert.IsInstanceOf<List<FunkoPops>>(result);
        }

        [Test]
        public async Task GetFunkosWishlist_BadRequest_Test()
        {
            var mockHttpService = new MockHttpServiceUnsuccessful();
            var funkoService = new FunkoService(mockHttpService);
            var mockUrl = "https://example.com";

            var response = await funkoService.GetFunkosWishlist(mockUrl);

            NUnit.Framework.Assert.IsNull(response);
        }

        //Tests for AddFunkoFromData
        [Test]
        public async Task AddFunkoFromData_SuccessfulPost_Test()
        {
            var mockHttpService = new MockHttpService();
            var funkoService = new FunkoService(mockHttpService);
            var mockUrl = "https://example.com";

            FunkoPops funko = new FunkoPops();
            funko.title = "Title";
            funko.price = 100;
            funko.imageName = "image";
            funko.handle = "handle";
            funko.series?.Add("Series title");

            var response = await funkoService.AddFunkoFromData(funko,mockUrl);

            var result = await funkoService.GetFunkos(mockUrl);
            
            foreach (var item in response)
            {
                result.Add(item);
            }
            foreach (var item in result)
            {
                Console.WriteLine(item.title);
            }
            NUnit.Framework.Assert.IsInstanceOf<List<FunkoPops>>(result);
            NUnit.Framework.Assert.AreEqual(3, result.Count);

        }

    }
}

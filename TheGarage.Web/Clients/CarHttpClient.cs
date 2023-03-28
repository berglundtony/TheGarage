using System.Net.Http;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TheGarage.Web.Models;

namespace TheGarage.Web.Clients
{
  

    public class CarHttpClient
    {
          private readonly HttpClient _httpClient;

        public CarHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }

        public async Task<Response<CarsContainer>> GetCars()
        {
            var response = await _httpClient.GetAsync(@"?query=
                { cars
                    { 
                      registryNumber 
                      brand 
                      model 
                      yearModel 
                      color 
                    }
                }");

            //var settings = new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore,
            //    MissingMemberHandling = MissingMemberHandling.Ignore
            //};
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<CarsContainer>>(stringResult);

        }
    }
}

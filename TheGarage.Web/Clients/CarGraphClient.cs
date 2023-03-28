using GraphQL.Client.Abstractions;
using GraphQL.Client;
using GraphQL.Client.Http;
using TheGarage.Web.Models;
using Microsoft.Extensions.Configuration;
using GraphQL;
using Newtonsoft.Json;

namespace TheGarage.Web.Clients
{
    public class CarGraphClient 
    {
        private readonly IGraphQLClient _client;

        public CarGraphClient(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<CarModel> GetCar(string registryNumber)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                  query carsQuery($registryNumber: String!){
                    car(registryNumber: $registryNumber){
                    registryNumber
                    brand 
                    model 
                    yearModel 
                    color     
                  }
              }",
                Variables = new { registryNumber = registryNumber }
            };
            var response = await _client.SendQueryAsync<CarsContainerType>(query);
            return response.Data.Car;
        }

        public async Task<CarModel>AddCar(CarModel car)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                mutation add($car: CarInputType)
                {
                    createCar(car: $car)
                    {
                        registryNumber
                        brand 
                        model 
                        yearModel 
                        color   
                    }
                }",
                Variables = new { car }
            };
            var response = await _client.SendMutationAsync<CarModel>(query);
            return response.Data;
        }

        public async Task<CarModel> UpdateCar(CarModel car)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                mutation update($car: CarInputType)
                {
                    updateCar(car: $car)
                    {
                        registryNumber
                        brand 
                        model 
                        yearModel 
                        color   
                    }
                }",
                Variables = new { car }
            };
            var response = await _client.SendMutationAsync<CarModel>(query);
            return response.Data;
        }

        public async Task<CarModel> DeleteCar(string registryNumber)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                        mutation($registryNumber: String!){
                            deleteCar(registryNumber: $registryNumber)
                            {
                                registryNumber
                                brand 
                                model 
                                yearModel 
                                color   
                            }
                        }",
                Variables = new { registryNumber = registryNumber }
            };

            var response = await _client.SendMutationAsync<CarsContainerType>(query);
            return response.Data.Car;
        }
    }
}

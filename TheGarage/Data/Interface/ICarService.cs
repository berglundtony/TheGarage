using GraphQL.Types;
using System.ComponentModel.Design;
using TheGarage.Data.Entities;
using TheGarage.Data.Models;
using TheGarage.GraphQL.Types;
using TheGarage.Web.Models;

namespace TheGarage.Data.Interface
{
    public interface ICarService
    {
        Task<List<Car>> GetCars();
        Task<Car?> GetCarByRegNumberAsync(string registryNumber);
        Car? GetCarByRegNumber(string registryName);
        Task<Car?> CreateCar(CarModel cartype);
        Task<Car?> AddCar(Car car);
        Task<Car?> UpdateCar(Task<Car?> dbCar, Car car);
        Task<Car?> DeleteCar(Car? car);

    }
}

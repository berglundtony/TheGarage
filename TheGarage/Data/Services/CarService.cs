using Microsoft.EntityFrameworkCore;
using TheGarage.Data.Entities;
using TheGarage.Data.Interface;
using TheGarage.Data.Models;
using TheGarage.GraphQL.Types;
using TheGarage.Web.Models;

namespace TheGarage.Data.Services
{
    public class CarService : ICarService
    {
        private readonly CarDbContext _dbContext;

        public CarService(CarDbContext dbContext)
        {
            _dbContext = dbContext; 
        }


        public async Task<List<Car>> GetCars()
        {
            return await _dbContext.Cars.ToListAsync();
        }


        public async Task<Car?> GetCarByRegNumberAsync(string registryNumber)
        {
            Car car = new Car();

            if (registryNumber != null)
                car = await _dbContext.Cars.SingleOrDefaultAsync(p => p.RegistryNumber == registryNumber);

            return car;
        }

        public Car? GetCarByRegNumber(string registryNumber)
        {
            Car car = new Car();

            if (registryNumber != null)
                car = _dbContext.Cars.SingleOrDefault(p => p.RegistryNumber == registryNumber);

            return car;
        }

        public async Task<Car?> CreateCar(CarModel cartype)
        {
            if(cartype != null)
            {
                var car = new Car()
                {
                    RegistryNumber = cartype.RegistryNumber,
                    Brand = cartype.Brand,
                    Model = cartype.Model,
                    YearModel = cartype.YearModel,
                    Color = cartype.Color
                };
                if (car != null)
                {
                    _dbContext.Cars.Add(car);
                    _dbContext.SaveChangesAsync();
                   
                }
                return await Task.FromResult(car ?? new Car());
            }
            return await Task.FromResult(new Car());
        }

        public async Task<Car?> AddCar(Car car)
        {
            if (car != null)
            {
                _dbContext.Cars.Add(car);
                await _dbContext.SaveChangesAsync();
            }
            return car ?? new Car();
        }

        public async Task<Car?> UpdateCar(Task<Car> dbCar, Car car)
        {
            dbCar.Result.RegistryNumber = car.RegistryNumber;
            dbCar.Result.Brand = car.Brand;
            dbCar.Result.Model = car.Model;
            dbCar.Result.Color = car.Color;
            dbCar.Result.YearModel = car.YearModel;
            if (car != null)
            {
                _dbContext.Cars.Update(dbCar.Result);
                await _dbContext.SaveChangesAsync();
            }
            return car;
        }

        public async Task<Car?> DeleteCar(Car? car)
        {
            if(car != null)
            {
                _dbContext.Cars.Remove(car);
                await _dbContext.SaveChangesAsync();
            }
            return car;
        }

    }
}

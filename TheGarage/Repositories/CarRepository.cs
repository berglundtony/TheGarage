using Microsoft.EntityFrameworkCore;
using TheGarage.Data;
using TheGarage.Data.Entities;

namespace TheGarage.Repositories
{
    public class CarRepository
    {
        private readonly CarDbContext _dbContext;

        public CarRepository(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        // Im not sure if i need this
        public Task<Car> GetOne(string regnumber)
        {
            return _dbContext.Cars.SingleAsync(p => p.RegistryNumber == regnumber);
        }

        public async Task<Car> AddCar(Car car)
        {
            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync();
            return car;
        }
    }
}

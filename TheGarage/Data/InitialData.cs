using Microsoft.EntityFrameworkCore;
using TheGarage.Data.Entities;

namespace TheGarage.Data
{
    internal class InitialData
    {
        private readonly ModelBuilder modelBuilder;

        public InitialData(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            this.modelBuilder.Entity<Car>().HasData(
                new Car() { RegistryNumber = "OMH525", Brand="Volksvagen", Color="White", Model="Golf Manhattan", YearModel=2000 }
                );
        }
    }
}
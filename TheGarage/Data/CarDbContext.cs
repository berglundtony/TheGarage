using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TheGarage.Data.Entities;

namespace TheGarage.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(
               entity =>
               {
                   entity.HasKey(id => id.RegistryNumber);
                   entity.ToTable("Car");
               });

            base.OnModelCreating(modelBuilder);
            new InitialData(modelBuilder).Seed();
        }
    }
}

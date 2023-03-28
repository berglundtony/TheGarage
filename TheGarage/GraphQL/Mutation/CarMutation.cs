using GraphQL;
using GraphQL.Types;
using TheGarage.Data;
using TheGarage.Data.Entities;
using TheGarage.Data.Interface;
using TheGarage.GraphQL.Types;
using TheGarage.Repositories;
using TheGarage.Web.Models;

namespace TheGarage.GraphQL.Mutation
{
    public class CarMutation: ObjectGraphType
    {
        public CarMutation(ICarService carService)
        {
            Field<CarType>("createCar")
                .Argument<CarInputType>("car")
                .ResolveAsync(async context =>
                {
                    var car = context.GetArgument<Car>("car");
                    var carModel = context.GetArgument<CarModel>("carModel");
                    return await carService.AddCar(car);
                });
              

            Field<CarType>("updateCar")
                .Argument<CarInputType>("car")
                .ResolveAsync(async context =>
                {
                    var car = context.GetArgument<Car>("car");
                    var carModel = context.GetArgument<CarModel>("carModel");
                    var dbCar = carService.GetCarByRegNumberAsync(car.RegistryNumber);
                    if (dbCar == null)
                    {
                        context.Errors.Add(new ExecutionError("couldn't find the car in the database."));
                        return null;
                    }
                    return await carService.UpdateCar(dbCar,car);
                });

            Field<CarType>("deleteCar")
                .Argument<NonNullGraphType<StringGraphType>>("registryNumber")
                .ResolveAsync(async context =>
                {
                    var registryNumber = context.GetArgument<String>("registryNumber");
                    var car = carService.GetCarByRegNumber(registryNumber);
                    if(car == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find the car in the database"));
                        return null;
                    }
                    await carService.DeleteCar(car);
                    return car; 
                });
        }
    }
}

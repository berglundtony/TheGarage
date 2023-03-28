using GraphQL;
using GraphQL.Builders;
using GraphQL.Types;
using TheGarage.Data.Interface;
using TheGarage.GraphQL.Types;
using TheGarage.Repositories;

namespace TheGarage.GraphQL.Queries
{
    public class CarQuery : ObjectGraphType
    {

        public CarQuery(ICarService carService)
        {
            Field<ListGraphType<CarType>>("cars")
                .Description("All cars")
                .ResolveAsync(async context => await carService.GetCars());

            Field<CarType>(
                "car")
                .Argument<StringGraphType>("registryNumber", "id of car")
                .ResolveAsync(async context => await carService.GetCarByRegNumberAsync(context.GetArgument<string>("registryNumber")).ConfigureAwait(false));
        }
    }
}

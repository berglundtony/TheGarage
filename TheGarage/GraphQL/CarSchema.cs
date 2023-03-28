using GraphQL.Types;
using TheGarage.GraphQL.Mutation;
using TheGarage.GraphQL.Queries;
using TheGarage.GraphQL.Types;

namespace TheGarage.GraphQL
{
    public class CarSchema : Schema
    {
        public CarSchema(IServiceProvider provider) : base(provider)
        {

            Query = provider.GetRequiredService<CarQuery>();
            Mutation = provider.GetRequiredService<CarMutation>();
        }
    }
}

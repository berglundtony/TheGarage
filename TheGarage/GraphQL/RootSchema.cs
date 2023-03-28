using GraphQL.Types;
using TheGarage.GraphQL.Mutation;
using TheGarage.GraphQL.Queries;

namespace TheGarage.GraphQL
{
    public class RootSchema : Schema
    {
        public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<RootMutation>();
        }
    }
}

using GraphQL.Types;

namespace TheGarage.GraphQL.Mutation
{
    public class RootMutation: ObjectGraphType
    {
        public RootMutation()
        {
            Field<CarMutation>("carMutation", resolve: context => new { });
        }
    }
}

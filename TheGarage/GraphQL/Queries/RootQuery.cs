using GraphQL.Types;

namespace TheGarage.GraphQL.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<CarQuery>("carQuery", resolve: context => new { });
        }
    }
}

using GraphQL.Types;
using TheGarage.Data.Interface;

namespace TheGarage.GraphQL.Types
{
    public class CarInputType: InputObjectGraphType
    {
        public CarInputType(ICarService car)
        {
            Field<NonNullGraphType<StringGraphType>>("registryNumber");
            Field<StringGraphType>("brand");
            Field<StringGraphType>("model");
            Field<IntGraphType>("yearModel");
            Field<StringGraphType>("Color");
        }
    }
}

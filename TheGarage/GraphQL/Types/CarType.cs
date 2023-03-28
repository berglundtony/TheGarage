using GraphQL.Types;
using TheGarage.Data.Entities;

namespace TheGarage.GraphQL.Types
{
    public class CarType: ObjectGraphType<Car>
    {
        public CarType()
        {
            Field(t => t.RegistryNumber, type: typeof(StringGraphType)).Description("The Id and reg number of the car");
            Field(t => t.Brand, type: typeof(StringGraphType)).Description("The brand of the car, Volvo for example");
            Field(t => t.YearModel, type: typeof(IntGraphType)).Description("The year when the car was made");
            Field(t => t.Model, type: typeof(StringGraphType)).Description("The model of the car, XC70 for example");
            Field(t => t.Color, type: typeof(StringGraphType)).Description("The color of the car");
        }
    }
}

namespace TheGarage.Web.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<ErrorModel> Errors { get; set; } 

        public void ThrewErrors()
        {
            if (Errors != null && Errors.Any())
                throw new GraphQlException(
                    $"Message: {Errors[0].Message} Code: {Errors[0].Code}");
        }
    }

    public class CarsContainer
    {
        public List<CarModel>? Cars { get; set; }
    }

    public class CarsContainerType
    {
        public CarModel Car { get; set; }
    }
}

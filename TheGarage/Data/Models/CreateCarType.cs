namespace TheGarage.Data.Models
{
    public class CreateCarType
    {
        public string RegistryNumber { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int YearModel { get; set; }
        public string? Color { get; set; }
    }
}
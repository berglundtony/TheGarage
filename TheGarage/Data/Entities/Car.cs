using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheGarage.Data.Entities
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RegistryNumber { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int YearModel { get; set; }
        public string? Color { get; set; }
    }
}

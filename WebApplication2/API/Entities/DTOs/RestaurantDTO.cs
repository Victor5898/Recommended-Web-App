using System.ComponentModel.DataAnnotations;

namespace WebApplication2.API.Entities.DTOs
{
    public class RestaurantDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        public string ImagePath { get; set; }

        public double Rating = 0.0;
    }
}

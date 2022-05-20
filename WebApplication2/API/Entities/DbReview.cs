using Recommended.Entities;
using WebApplication2.Entities;

namespace WebApplication2.API.Entities
{
    public class DbReview
    {
        public int Id { get; set; }
        public DbUser DbUser { get; set; }
        public int DbUserId { get; set; }
        public DbRestaurant DbRestaurant { get; set; }
        public int DbRestaurantId { get; set; }

        public DateTime PublishDate = DateTime.Now;
        public int RatingPoints { get; set; }
        public string Comment { get; set; }
    }
}

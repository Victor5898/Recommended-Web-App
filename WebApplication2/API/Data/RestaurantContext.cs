using Microsoft.EntityFrameworkCore;
using System.Threading;
using WebApplication2.Entities;

namespace WebApplication2.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {

        }

        public virtual DbSet<DbRestaurant> Restaurants { get; set; }
    }
}

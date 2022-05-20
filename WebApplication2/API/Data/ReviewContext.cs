using Microsoft.EntityFrameworkCore;
using WebApplication2.API.Entities;

namespace WebApplication2.API.Data
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options)
        {

        }
        public virtual DbSet<DbReview> Reviews { get; set; }
    }
}

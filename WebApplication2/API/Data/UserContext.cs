using Microsoft.EntityFrameworkCore;
using Recommended.Entities;

namespace Recommended.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public virtual DbSet<DbUser> Users { get; set; }
    }
}

using ContentManagementApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ContentManagementApplication.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Content> Contents { get; set; }
    }
}

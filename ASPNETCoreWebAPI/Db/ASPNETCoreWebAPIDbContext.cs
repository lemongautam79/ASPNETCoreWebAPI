using ASPNETCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebAPI.Db
{
    public class ASPNETCoreWebAPIDbContext(DbContextOptions<ASPNETCoreWebAPIDbContext> options) : DbContext(options)
    {

        // Students Table
        public DbSet<Student> Students => Set<Student>();

        // Users Table
        public DbSet<User> Users => Set<User>();

        public DbSet<Post> Posts => Set<Post>();

        public DbSet<Comment> Comments => Set<Comment>();
    }
}

using ASPNETCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebAPI.Db
{
    public class ASPNETCoreWebAPIDbContext(DbContextOptions<ASPNETCoreWebAPIDbContext> options) : DbContext(options)
    {

        // Students Table
        public DbSet<Student> Students => Set<Student>();
    }
}

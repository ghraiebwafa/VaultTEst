using Microsoft.EntityFrameworkCore;
using vaultTest.Models;

namespace vaulttest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } // DbSet for User model
    }
}
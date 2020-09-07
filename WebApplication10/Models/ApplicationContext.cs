using Microsoft.EntityFrameworkCore;

namespace PlumsailTestCaseBackend.Models
{
    public class ApplicationContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Submition> Submitions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
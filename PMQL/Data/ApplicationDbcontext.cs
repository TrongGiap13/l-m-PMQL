using Microsoft.EntityFrameworkCore;
using PMQL.Models;

namespace PMQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Person> Person { get; set; }
    }
}

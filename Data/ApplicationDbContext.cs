using APICRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace APICRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> employees { get; set; }
    }
}

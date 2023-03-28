using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nextwoidentity2023.Models;

namespace Nextwoidentity2023.Data
{
    public class NextwoDbContext:IdentityDbContext

    {
        public NextwoDbContext(DbContextOptions<NextwoDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

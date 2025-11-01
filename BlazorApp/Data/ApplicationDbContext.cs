using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Vistavki> vistavkis { get; set; }
        public DbSet<Posetiteli> posetitels { get; set; }
        public DbSet<Bilet> bilets { get; set; }
    }
}

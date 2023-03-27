using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-BQCVFF2\\JPMARINT; Database=superherodb; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}

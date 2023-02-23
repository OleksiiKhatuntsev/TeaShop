using Microsoft.EntityFrameworkCore;
using TeaShop.Models;

namespace TeaShop.Data
{
    public class TeaDbContext : DbContext
    {
        public TeaDbContext(DbContextOptions<TeaDbContext> options) : base(options)
        { }

        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}

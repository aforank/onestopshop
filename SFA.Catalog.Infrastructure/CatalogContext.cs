using Microsoft.EntityFrameworkCore;
using SFA.Catalog.Infrastructure.Entities;
using SFA.Catalog.Infrastructure.EntityConfigurations;

namespace SFA.Catalog.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RestaurantEntityTypeConfiguration());
        }
    }
}

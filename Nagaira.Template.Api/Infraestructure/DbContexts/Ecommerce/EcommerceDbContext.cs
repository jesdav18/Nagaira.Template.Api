using Microsoft.EntityFrameworkCore;
using Nagaira.Template.Api.Infraestructure.DbContexts.Ecommerce.Maps;

namespace Nagaira.Template.Api.Infraestructure.DbContexts.Ecommerce
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}

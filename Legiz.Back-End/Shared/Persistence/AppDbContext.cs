using Legiz.Back_End.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Legiz.Back_End.Shared.Persistence
{
    public class AppDbContext : DbContext
    {
        // Sets
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Convention Snake_Case
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
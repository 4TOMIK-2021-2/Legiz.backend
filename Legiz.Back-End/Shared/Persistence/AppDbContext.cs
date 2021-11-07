using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Legiz.Back_End.Shared.Persistence
{
    public class AppDbContext : DbContext
    {
        // Sets
        public DbSet<Score> Scores { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Convention Snake_Case
            builder.UseSnakeCaseNamingConvention();

            // Constraints
            builder.Entity<Score>().ToTable("Scores");
            builder.Entity<Score>().HasKey(p => p.Id);
            builder.Entity<Score>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Score>().Property(p => p.Star).IsRequired();
            builder.Entity<Score>().Property(p => p.Comment).IsRequired();
            
            // Relationships - at stand by
        }
    }
}
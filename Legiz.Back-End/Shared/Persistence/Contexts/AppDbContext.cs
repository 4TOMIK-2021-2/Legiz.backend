
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.SecurityBC.Domain.Models;
using Legiz.Back_End.Shared.Extensions;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Legiz.Back_End.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        
        // Sets
        public DbSet<LawService> LawServices { get; set; }
        public DbSet<CustomLegalCase> CustomLegalCases { get; set; }
        public DbSet<LegalAdvice> LegalAdvices { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<LegalDocument> LegalDocuments { get; set; }
        public DbSet<Score> Scores { get; set; }
        
        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // LAW SERVICE BC
            
            // Inheritance
            builder.Entity<LegalAdvice>().HasBaseType<LawService>();
            builder.Entity<CustomLegalCase>().HasBaseType<LawService>();
            
            // Constraints
            builder.Entity<LawService>().HasKey(p => p.Id);
            builder.Entity<LawService>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<LawService>().Property(p => p.Title).IsRequired();

            builder.Entity<LegalAdvice>().Property(p => p.Description).IsRequired();

            builder.Entity<CustomLegalCase>().Property(p => p.StartAt).IsRequired();
            builder.Entity<CustomLegalCase>().Property(p => p.FinishAt).IsRequired();
            
            builder.Entity<LegalDocument>().HasKey(p => p.Id);
            builder.Entity<LegalDocument>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<LegalDocument>().Property(p => p.Path).IsRequired();
            
            // Relationships
            builder.Entity<LegalDocument>()
                .HasMany(p => p.LegalAdvices)
                .WithOne(p => p.LegalDocument)
                .HasForeignKey(p => p.LegalDocumentId);
            
            builder.Entity<LegalDocument>()
                .HasMany(p => p.CustomLegalCases)
                .WithOne(p => p.LegalDocument)
                .HasForeignKey(p => p.LegalDocumentId);

            // USER PROFILE BC
            
            // Inheritance
            builder.Entity<Lawyer>().HasBaseType<User>();
            builder.Entity<Customer>().HasBaseType<User>();

            builder.Entity<User>().HasDiscriminator(p => p.UserType);

            // Constraints
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().IsUnicode();
            builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(40).IsRequired();
            builder.Entity<User>().Property(p => p.FirstName).IsRequired();
            builder.Entity<User>().Property(p => p.LastName).IsRequired();

            builder.Entity<Customer>().Property(p => p.Phone).IsRequired();
            builder.Entity<Customer>().Property(p => p.Dni).IsRequired().IsUnicode();

            builder.Entity<Lawyer>().Property(p => p.District).IsRequired();
            builder.Entity<Lawyer>().Property(p => p.PriceCustomContract).IsRequired();
            builder.Entity<Lawyer>().Property(p => p.PriceLegalAdvice).IsRequired();
            builder.Entity<Lawyer>().Property(p => p.Specialization).IsRequired();
            builder.Entity<Lawyer>().Property(p => p.University).IsRequired();

            builder.Entity<Subscription>().ToTable("Subscriptions");
            builder.Entity<Subscription>().HasKey(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subscription>().Property(p => p.Description).IsRequired();
            
            // Relationships
            builder.Entity<Subscription>()
                .HasMany(p => p.Lawyers)
                .WithOne(p => p.Subscription)
                .HasForeignKey(p => p.SubscriptionId);
            
            // Seed Data
            builder.Entity<Subscription>().HasData
            (
                new Subscription { Id = 1, Price = 60, Description = "New Subscription", State = EState.Current }
            );
            
            // NETWORKING BC

            // Constraints
            builder.Entity<Score>().ToTable("Scores");
            builder.Entity<Score>().HasKey(p => p.Id);
            builder.Entity<Score>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Score>().Property(p => p.Star).IsRequired();
            builder.Entity<Score>().Property(p => p.Comment).IsRequired();

            // Convention Snake_Case
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
using AutoMapper.Configuration;
using Legiz.Back_End.Shared.Extensions;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Legiz.Back_End.Shared.Persistence
{
    public class AppDbContext : DbContext
    {
        // Sets
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // USER PROFILE BC
            // Constraints
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired();
            builder.Entity<User>().Property(p => p.Username).IsRequired().IsUnicode();
            builder.Entity<User>().Property(p => p.Password).IsRequired().IsUnicode();

            builder.Entity<Lawyer>().Property(p => p.Phone).IsRequired().IsUnicode();
            builder.Entity<Lawyer>().Property(p => p.PriceCustomContract).IsRequired();
            builder.Entity<Lawyer>().Property(p => p.PriceLegalAdvice).IsRequired();
            builder.Entity<Lawyer>().Property(p => p.Specialization).IsRequired();

            // Inheritance
            builder.Entity<User>()
                .HasDiscriminator<string>("user_type")
                .HasValue<Lawyer>("user_lawyer")
                .HasValue<Customer>("user_customer");
            
            // Seed Data
            builder.Entity<Lawyer>().HasData
            (
                new Lawyer { Id = 300, Username = "Mauricio", Password = "123", Email = "m@hotmail.com", Specialization = ESpecialization.CivilLaw, PriceCustomContract = 40, PriceLegalAdvice = 100, Phone = "937598438" },
                new Lawyer { Id = 301, Username = "Gustavo", Password = "1234", Email = "g@hotmail.com", Specialization = ESpecialization.ElderLaw, PriceCustomContract = 50, PriceLegalAdvice = 200, Phone = "988778896" }
                );

            // Convention Snake_Case
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
using BookYourResidency.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Api.Models
{
    public class BookYourResidencyDbContext : DbContext
    {
        public BookYourResidencyDbContext()
        {

        }
        public BookYourResidencyDbContext(DbContextOptions<BookYourResidencyDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyType> Types { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<TenantsType> TenantsTypes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Locality> Localities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Name=BookYourResidencyDB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity => {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsRequired()
                    .IsUnicode(true);
            });
            modelBuilder.Entity<State>(entity =>
            {
                entity.HasOne(b => b.Country).WithMany(i => i.States).HasForeignKey(k => k.CountryId).OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(30)
               .IsUnicode(true);
            });
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasOne(b => b.State).WithMany(i => i.Cities).HasForeignKey(k => k.StateId).OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true);
            });
            modelBuilder.Entity<Locality>(entity =>
            {
                entity.HasOne(b => b.City).WithMany(i => i.Localities).HasForeignKey(k => k.CityId).OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(50)
              .IsUnicode(true);
            });
            modelBuilder.Entity<User>(entity => {
                entity.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(25);
                entity.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(25);
                entity.Property(e => e.Password)
                   .IsRequired()
                   .HasMaxLength(10);
                entity.Property(e => e.EmailAddress)
                   .IsRequired()
                   .HasMaxLength(30)
                   .IsUnicode(true);
            });
            modelBuilder.Entity<Image>(entity => {
                entity.HasOne(b => b.Property).WithMany(i => i.Images).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Property>(entity => {
                entity.HasOne(b => b.Location).WithOne(i => i.Property).HasForeignKey<Location>(k => k.PropertyId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(s => s.User).WithMany(i => i.Properties).HasForeignKey(k => k.UserId).OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.Message)
                   .IsRequired(false)
                   .HasMaxLength(50)
                   .IsUnicode(false);
                entity.Property(e => e.Phone)
                   .IsRequired(true)
                   .IsFixedLength(true)
                   .HasMaxLength(12)
                   .IsUnicode(false);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}

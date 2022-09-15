using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Restaurants.Models
{
    public partial class RestaurantDBContext : DbContext
    {
        public bool IgnoreFilter { get; set; }
        public RestaurantDBContext()
        {
        }

        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantMenu> RestaurantMenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SAMEEH-ABUTAIMA;Database=restaurantdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Details");

                entity.Property(e => e.ProfitInNis).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ProfitInUsd).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.RestaurantName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Customer_RestaurantMenuCustomer");

                entity.HasOne(d => d.RestaurantMenu)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RestaurantMenuId)
                    .HasConstraintName("FK_RestaurantMenu_RestaurantMenuCustomer");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<RestaurantMenu>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.MealName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PriceInNis).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PriceInUsd)
                    .HasColumnType("numeric(15, 6)")
                    .HasComputedColumnSql("([PriceInNis]/(3.5))", false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantMenus)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK_RestaurantMenus_Restaurants");
            });

            modelBuilder.Entity<Restaurant>().HasQueryFilter(r => !r.Archived || IgnoreFilter);
            modelBuilder.Entity<RestaurantMenu>().HasQueryFilter(m => !m.Archived || IgnoreFilter);
            modelBuilder.Entity<Customer>().HasQueryFilter(c => !c.Archived || IgnoreFilter);
            modelBuilder.Entity<Order>().HasQueryFilter(o => !o.Archived || IgnoreFilter);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

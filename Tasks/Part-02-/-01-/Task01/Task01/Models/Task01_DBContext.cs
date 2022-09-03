using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Task01.Models
{
    public partial class Task01_DBContext : DbContext
    {
        public bool IgnoreFilter { get; set; }
        public Task01_DBContext()
        {
        }

        public Task01_DBContext(DbContextOptions<Task01_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               //optionsBuilder.UseSqlServer("Server=SAMEEH-ABUTAIMA;Database=Task01_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>().HasQueryFilter(usr => usr.Archived==0 || IgnoreFilter );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

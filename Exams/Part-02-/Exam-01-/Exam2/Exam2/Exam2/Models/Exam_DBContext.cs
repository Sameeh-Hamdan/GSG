using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Exam2.Models
{
    public partial class Exam_DBContext : DbContext
    {
        //public bool IgnoreFilter { get; set; }
        public Exam_DBContext()
        {
        }

        public Exam_DBContext(DbContextOptions<Exam_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SAMEEH-ABUTAIMA;Database=Exam_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sub)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Items__SubId__37A5467C");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("Sub_Categories");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sub_Categ__CatId__267ABA7A");
            });
            //modelBuilder.Entity<User>().HasQueryFilter(usr => usr.Archived == 0 || IgnoreFilter);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

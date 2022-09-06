using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Models
{
    public class CodeFirstDbContext:DbContext
    {
        public CodeFirstDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmpProjects>().HasKey(e => new { e.ProjectId, e.EmployeesId });
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmpProjects> EmpProjects { get; set; }
    }
}

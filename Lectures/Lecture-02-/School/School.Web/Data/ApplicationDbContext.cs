using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Manager> Managers { get; set; }
    }
}

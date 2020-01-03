using Microsoft.EntityFrameworkCore;
using PVS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVS.Persistence.Core
{
    public class PVSContext : DbContext
    {
        public PVSContext() : base()
        {

        }

        public PVSContext(DbContextOptions<PVSContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-15RAB9Q\\SQLEXPRESS;Database = PVS; Integrated Security = true");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProjectMember>()
                .HasKey(c => new { c.ProjectId, c.UserId });
        }
    }
}

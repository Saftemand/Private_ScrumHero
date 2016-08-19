using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Private_ScrumHero.Models;

namespace Private_ScrumHero.Dao
{
    public class AppDbContext //: DbContext
    {
        //public DbSet<Project> Projects { get; set; }
        //public DbSet<Backlog> Backlogs { get; set; }
        //public DbSet<DeveloperTask> DeveloperTasks { get; set; }
        //public DbSet<Release> Releases { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Sprint> Sprints { get; set; }
        //public DbSet<Team> Teams { get; set; }
        //public DbSet<UserStory> UserStories { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }

        //public AppDbContext() { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Project>().Property(p => p.CreatedAt).HasColumnType("datetime2").HasPrecision(0);
        //    modelBuilder.Entity<Project>().Property(p => p.LastModifiedAt).HasColumnType("datetime2").HasPrecision(0);
        //    modelBuilder.Entity<UserStory>().Property(u => u.CreatedAt).HasColumnType("datetime2").HasPrecision(0);
        //    modelBuilder.Entity<UserStory>().Property(u => u.LastModifiedAt).HasColumnType("datetime2").HasPrecision(0);

        //    modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
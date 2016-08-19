using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Private_ScrumHero.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IModel
    {
        public virtual List<Team> Teams { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Backlog> Backlogs { get; set; }
        public DbSet<DeveloperTask> DeveloperTasks { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUserRole> TeamUserRoles { get; set; }
        public DbSet<UserStory> UserStories { get; set; }
        

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Property(p => p.CreatedAt).HasColumnType("datetime2").HasPrecision(0);
            modelBuilder.Entity<Project>().Property(p => p.LastModifiedAt).HasColumnType("datetime2").HasPrecision(0);
            modelBuilder.Entity<UserStory>().Property(u => u.CreatedAt).HasColumnType("datetime2").HasPrecision(0);
            modelBuilder.Entity<UserStory>().Property(u => u.LastModifiedAt).HasColumnType("datetime2").HasPrecision(0);

            //modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            //NOTE: Do not try to use cascade on delete in EF. It is very hard to configure
            //modelBuilder.Entity<Project>().HasOptional(p => p.Team).WithRequired().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }



    }
}
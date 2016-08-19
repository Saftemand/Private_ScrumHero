using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Private_ScrumHero.Models;

namespace Private_ScrumHero.Dao
{
    public class ApplicationDbContextSeeder : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            
            //Project project = new Project()
            //{
            //    CreatedAt = DateTime.Now, LastModifiedAt = DateTime.Now, Name = "Tiny Teddy"
            //};
            //project.Team = new Team(){ Project = project, TeamName = "The Trusted Advisors" };
            //project.Team.TeamUserRoles = new List<TeamUserRole>();
            //context.Projects.Add(project);
            base.Seed(context);
        }
    }
}
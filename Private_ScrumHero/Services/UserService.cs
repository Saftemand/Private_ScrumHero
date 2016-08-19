using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.Models;

namespace Private_ScrumHero.Services
{
    public class UserService
    {
        public static List<ApplicationUser> GetAllUsers()
        {
            return ApplicationDbContext.Create().Users.ToList();
        }

        public static List<ApplicationUser> GetAllUsersNotInProject(int projectId)
        {
            return ApplicationDbContext.Create().Users
                .Where(x => x.Teams.Count(t => t.Project.ProjectId == projectId) == 0).ToList();
        }

        public static List<ApplicationUser> GetAllUsersInProject(int projectId)
        {
            return ApplicationDbContext.Create().Users
                .Where(x => x.Teams.Count(t => t.Project.ProjectId == projectId) > 0).ToList();
        }


    }
}
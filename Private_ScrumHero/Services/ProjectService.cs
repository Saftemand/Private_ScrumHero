using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Private_ScrumHero.ModelConverters;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.Services
{
    public class ProjectService
    {
        internal static List<ProjectViewModel> FindAll()
        {
            List<ProjectViewModel> viewModels = new List<ProjectViewModel>();
            using (ApplicationDbContext appDbContext = new ApplicationDbContext())
            {
                viewModels = appDbContext.Projects.
                    Select(x=> new ProjectViewModel()
                    {
                        ProjectId = x.ProjectId, Name = x.Name, CreatedAt = x.CreatedAt, LastModifiedAt = x.LastModifiedAt
                    }).ToList();
            }
            return viewModels;
        }

        internal static void CreateProject(ProjectViewModel viewModel, ApplicationUser projectCreator)
        {
            Project project = new Project();
            project.Name = viewModel.Name;
            project.CreatedAt = project.LastModifiedAt = DateTime.Now;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                ApplicationUser persistedUser = context.Users.First(u => u.Id == projectCreator.Id);
                
                project.Team = new Team
                {
                    TeamUserRoles = new List<TeamUserRole>
                        {
                            new TeamUserRole() {User = persistedUser, Role = "Administrator"}
                        }
                };

                persistedUser.Teams.Add(project.Team);

                project.Backlog = new Backlog()
                {
                    UserStories = new List<UserStory>()
                };

                project.Releases = new List<Release>();

                context.Projects.Add(project);
                context.SaveChanges();
            }
        }

        internal static void AddUserToProject(ApplicationUser user, int projectId)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateProject(ProjectViewModel updatedProject)
        {
            using (ApplicationDbContext appDbContext = new ApplicationDbContext())
            {
                Project oldProject = appDbContext.Projects.First(x => x.ProjectId == updatedProject.ProjectId);
                oldProject.LastModifiedAt = DateTime.Now;
                oldProject.Name = updatedProject.Name;
                appDbContext.SaveChanges();
            }
        }

        internal static void DeleteProject(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Project project = context.Projects.Include("Backlog").Include(p => p.Team.TeamUserRoles.Select(tur => tur.User)).First(p => p.ProjectId == id);

                foreach (Release release in project.Releases.ToList())
                {

                    foreach (Sprint sprint in release.Sprints.ToList())
                    {
                        context.Sprints.Remove(sprint);
                    }

                    context.Releases.Remove(release);
                }
                foreach (UserStory userStory in project.Backlog.UserStories.ToList())
                {
                    context.UserStories.Remove(userStory);
                }
                foreach (TeamUserRole teamUserRole in project.Team.TeamUserRoles.ToList())
                {
                    context.TeamUserRoles.Remove(teamUserRole);
                }

                context.Teams.Remove(project.Team);
                context.Backlogs.Remove(project.Backlog);
                context.Projects.Remove(project);

                context.SaveChanges();
            }

        }

        internal static ProjectViewModel FindById(int? id)
        {
            ProjectViewModel viewModel = null;
            
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Project project = context.Projects.Include("Backlog.UserStories")
                     .Include(p => p.Team.TeamUserRoles.Select(tur => tur.User))
                     .First(p => p.ProjectId == id);

                if (project == null)
                {
                    return null;
                }
                
                viewModel = new ProjectViewModel()
                {
                    Name = project.Name, ProjectId = project.ProjectId, 
                    CreatedAt = project.CreatedAt, LastModifiedAt = project.LastModifiedAt,
                    BacklogId = project.Backlog.BacklogId, 
                };

                viewModel.Team = TeamService.FindById(project.Team.TeamId);
            }
            return viewModel;
        }

        internal static List<ProjectViewModel> FindRelatedToApplicationUser(ApplicationUser user)
        {
            List<ProjectViewModel> viewModels = new List<ProjectViewModel>();

            using (ApplicationDbContext appDbContext = new ApplicationDbContext())
            {
                var teams = appDbContext.Teams;

                viewModels = appDbContext.Projects
                    .Include(p => p.Backlog).Include(p => p.Team)
                    .Where(p => p.Team.TeamUserRoles.Count(tur => tur.User.Id == user.Id) > 0)
                    .Select(x => new ProjectViewModel()
                    {
                        ProjectId = x.ProjectId,
                        Name = x.Name,
                        CreatedAt = x.CreatedAt,
                        LastModifiedAt = x.LastModifiedAt, 
                        BacklogId = x.Backlog.BacklogId,
                        TeamId = x.Team.TeamId
                    }).ToList();
            }

            return viewModels;
        }
    }
}
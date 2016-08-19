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
    public class UserStoryService
    {
        internal static UserStoryViewModel FindById(int? id)
        {
            UserStoryViewModel viewModel = null;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                viewModel = new UserStoryConverter().ToViewModel(context.UserStories
                    .Include(us => us.Backlog).Include(us => us.Release).Include(us => us.Sprint).Include(us => us.DeveloperTasks).
                    FirstOrDefault(us => us.UserStoryId == id));
            }

            return viewModel;
        }

        internal static List<ViewModels.UserStoryViewModel> FindByBacklogId(int backlogId)
        {
            List<UserStoryViewModel> viewModels = null;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                viewModels = new UserStoryConverter().ToViewModels(context.UserStories.Include(us => us.Backlog).Where(us => us.Backlog.BacklogId == backlogId).ToList());
            }

            return viewModels;
        }

        internal static UserStory CreateUserStory(UserStoryViewModel viewModel)
        {
            UserStory userStory = new UserStory();
            userStory.CreatedAt = DateTime.Now;
            userStory.LastModifiedAt = DateTime.Now;
            userStory.Name = viewModel.Name;
            userStory.LocalId = "US:TBA";
            userStory.DeveloperTasks = new List<DeveloperTask>();
            userStory.Release = null;
            userStory.Sprint = null;
            
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                userStory.Backlog = context.Backlogs.First(b => b.BacklogId == viewModel.BacklogId);
                context.UserStories.Add(userStory);
                context.SaveChanges();
            }

            return userStory;
        }



        internal static void UpdateUserStory(UserStoryViewModel viewModel)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                UserStory userStory = context.UserStories
                    .Include(us => us.Backlog).Include(us => us.Release).Include(us => us.Sprint).Include(us => us.DeveloperTasks)
                    .First(us => us.UserStoryId == viewModel.UserStoryId);

                userStory.LastModifiedAt = DateTime.Now;
                userStory.Name = viewModel.Name;
                
                //context.Entry(userStory).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        internal static void DeleteById(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                UserStory userStory = context.UserStories.First(us => us.UserStoryId == id);
                
                context.UserStories.Remove(userStory);
                
                context.Entry(userStory).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
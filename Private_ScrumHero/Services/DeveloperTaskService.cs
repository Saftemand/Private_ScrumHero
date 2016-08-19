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
    public class DeveloperTaskService
    {
        public static DeveloperTaskViewModel FindById(int? id)
        {
            DeveloperTaskViewModel viewModel = null;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                viewModel = new DeveloperTaskConverter()
                    .ToViewModel(context.DeveloperTasks.Include(dt => dt.UserStory).FirstOrDefault(dt => dt.DeveloperTaskId == id));
            }

            return viewModel;
        }

        public static List<DeveloperTaskViewModel> FindByIds(List<int> developerTaskIds)
        {
            List<DeveloperTaskViewModel> viewModels = new List<DeveloperTaskViewModel>();

            foreach (int id in developerTaskIds)
            {
                viewModels.Add(FindById(id));
            }

            return viewModels;
        }

        public static List<DeveloperTaskViewModel> FindByUserStory(int userStoryId)
        {
            List<DeveloperTaskViewModel> viewModels = new List<DeveloperTaskViewModel>();

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                viewModels = new DeveloperTaskConverter()
                    .ToViewModels(context.DeveloperTasks.Where(dt => dt.UserStory.UserStoryId == userStoryId).ToList());
            }

            return viewModels;
        }

        public static void CreateDeveloperTask(DeveloperTaskViewModel viewModel)
        {
            DeveloperTask developerTask = new DeveloperTask();
            developerTask.LocalId = viewModel.LocalId;
            developerTask.DeveloperTaskName = viewModel.DeveloperTaskName;
            
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                developerTask.UserStory = context.UserStories.First(us => us.UserStoryId == viewModel.UserStoryId);

                context.DeveloperTasks.Add(developerTask);
                context.SaveChanges();
            }
        }

        public static void UpdateDeveloperTask(DeveloperTaskViewModel viewModel)
        {
            DeveloperTask developerTask = null;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                developerTask = context.DeveloperTasks.First(dt => dt.DeveloperTaskId == viewModel.DeveloperTaskId);
                
                developerTask.DeveloperTaskName = viewModel.DeveloperTaskName;
                
                context.SaveChanges();
            }
        }

        public static void DeleteDeveloperTask(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                DeveloperTask developerTask = context.DeveloperTasks.First(dt => dt.DeveloperTaskId == id);
                context.DeveloperTasks.Remove(developerTask);
                context.SaveChanges();
            }
        }
    }
}
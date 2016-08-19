using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Private_ScrumHero.ModelConverters;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.Services
{
    public class BacklogService
    {
        public static BacklogViewModel FindById(int? id)
        {
            BacklogViewModel viewModel = null;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                viewModel = new BacklogConverter()
                    .ToViewModel(context.Backlogs.Include(b => b.Project).FirstOrDefault(b => b.BacklogId == id));
            }

            viewModel.userStories = UserStoryService.FindByBacklogId(viewModel.BacklogId);

            return viewModel;
        }

        public static BacklogViewModel FindByProjectId(int? projectId)
        {
            BacklogViewModel viewModel = null;
            
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                viewModel = new BacklogConverter()
                    .ToViewModel(context.Backlogs.Include(b => b.Project).FirstOrDefault(b => b.Project.ProjectId == projectId));
            }

            viewModel.userStories = UserStoryService.FindByBacklogId(viewModel.BacklogId);

            return viewModel;
        }
    }
}
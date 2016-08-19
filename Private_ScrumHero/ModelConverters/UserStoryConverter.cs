using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.ModelConverters;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ModelConverters
{
    public class UserStoryConverter : BaseConverter<UserStoryViewModel, UserStory>
    {
        private SprintViewModel _sprint = null;
        private ReleaseViewModel _release = null;
        private List<DeveloperTaskViewModel> _developerTasks = null;

        protected override void AssignRelevantPropertiesToViewModel(UserStory model)
        {
            //_viewModel.Sprint = _sprint ?? new SprintConverter().ToViewModel(model.Sprint);
            //_viewModel.Release = _release ?? new ReleaseConverter().ToViewModel(model.Release);
            //_viewModel.DeveloperTasks = _developerTasks ?? new DeveloperTaskConverter().ToViewModels(model.DeveloperTasks);
        }

        protected override void InstantiateViewModel(UserStory model)
        {
            _viewModel = new UserStoryViewModel()
            {
                UserStoryId = model.UserStoryId,
                Name = model.Name,
                LastModifiedAt = model.LastModifiedAt,
                CreatedAt = model.CreatedAt,
                BacklogId = model.Backlog.BacklogId,
                LocalId = model.LocalId,
                ReleaseId = model.Release != null ? model.Release.ReleaseId : -1,
                SprintId = model.Sprint != null ? model.Sprint.SprintId : -1,
                DeveloperTaskIds = model.DeveloperTasks.Select(dt => dt.DeveloperTaskId).ToList()
            };
        }

        protected override void FindRelevantProperties(params object[] viewModelProperties)
        {
            //foreach (IViewModel viewModel in viewModelProperties)
            //{
            //    if (viewModel.GetType() == typeof(SprintViewModel))
            //    {
            //        _sprint = viewModel as SprintViewModel;
            //    }
            //    if (viewModel.GetType() == typeof(ApplicationUserViewModel))
            //    {
            //        _release = viewModel as ReleaseViewModel;
            //    }
            //    if (viewModel.GetType() == typeof(DeveloperTaskViewModel))
            //    {
            //        _developerTasks = new List<DeveloperTaskViewModel>() { viewModel as DeveloperTaskViewModel };
            //    }
            //    if (viewModel.GetType() == typeof(DeveloperTaskViewModel))
            //    {
            //        _developerTasks = viewModel as List<DeveloperTaskViewModel>;
            //    }
            //}
        }
    }
}
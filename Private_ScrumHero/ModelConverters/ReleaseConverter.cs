using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ModelConverters
{
    public class ReleaseConverter : BaseConverter<ReleaseViewModel, Release>
    {
        //private ProjectViewModel _project = null;
        //private List<UserStoryViewModel> _userStories = null;
        //private List<SprintViewModel> _sprints = null;

        protected override void AssignRelevantPropertiesToViewModel(Release model)
        {
            //_viewModel.Project = new ProjectConverter().ToViewModel(model.Project);
            //_viewModel.UserStories = new UserStoryConverter().ToViewModels(model.UserStories);
            //_viewModel.Sprints = new SprintConverter().ToViewModels(model.Sprints);
        }

        protected override void InstantiateViewModel(Release model)
        {
            _viewModel = new ReleaseViewModel()
            {
                ReleaseId = model.ReleaseId,
                ReleaseName = model.ReleaseName,
                ProjectId = model.Project.ProjectId,
                UserStoryIds = model.UserStories.Select(us => us.UserStoryId).ToList(),
                SprintIds = model.Sprints.Select(s => s.SprintId).ToList()
            };
        }

        protected override void FindRelevantProperties(params object[] viewModelProperties)
        {
            //foreach (IViewModel viewModel in viewModelProperties)
            //{
            //    if (viewModel.GetType() == typeof(ProjectViewModel))
            //    {
            //        _project = viewModel as ProjectViewModel;
            //    }
            //    if (viewModel.GetType() == typeof(UserStoryViewModel))
            //    {
            //        _userStories = new List<UserStoryViewModel>() { viewModel as UserStoryViewModel };
            //    }
            //    if (viewModel.GetType() == typeof(List<UserStoryViewModel>))
            //    {
            //        _userStories =  viewModel as List<UserStoryViewModel>;
            //    }
            //    if (viewModel.GetType() == typeof(SprintViewModel))
            //    {
            //        _sprints = new List<SprintViewModel>() { viewModel as SprintViewModel };
            //    }
            //    if (viewModel.GetType() == typeof(List<UserStoryViewModel>))
            //    {
            //        _sprints = viewModel as List<SprintViewModel>;
            //    }
            //}
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ModelConverters
{
    public class SprintConverter : BaseConverter<SprintViewModel, Sprint>
    {
        private ReleaseViewModel _release = null;
        private List<UserStoryViewModel> _userStories = null;

        protected override void AssignRelevantPropertiesToViewModel(Sprint model)
        {
            //_viewModel.Release = _release ?? new ReleaseConverter().ToViewModel(model.Release);
            //_viewModel.UserStories = _userStories ?? new UserStoryConverter().ToViewModels(model.UserStories);
        }

        protected override void InstantiateViewModel(Sprint model)
        {
            _viewModel = new SprintViewModel()
            {
                SprintId = model.SprintId,
                localId = model.localId,
                SprintName = model.SprintName,
                ReleaseId = model.Release.ReleaseId,
                UserStoryIds = model.UserStories.Select(us => us.UserStoryId).ToList()
            };
        }

        protected override void FindRelevantProperties(params object[] viewModelProperties)
        {
            //foreach (IViewModel viewModel in viewModelProperties)
            //{
            //    if (viewModel.GetType() == typeof(ReleaseViewModel))
            //    {
            //        _release = viewModel as ReleaseViewModel;
            //    }
            //    if (viewModel.GetType() == typeof(UserStoryViewModel))
            //    {
            //        _userStories = new List<UserStoryViewModel>() { viewModel as UserStoryViewModel };
            //    }
            //    if (viewModel.GetType() == typeof(List<UserStoryViewModel>))
            //    {
            //        _userStories = viewModel as List<UserStoryViewModel>;
            //    }
            //}
        }
    }
}
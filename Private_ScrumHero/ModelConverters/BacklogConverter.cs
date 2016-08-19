using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ModelConverters
{
    public class BacklogConverter : BaseConverter<BacklogViewModel, Backlog>
    {
        
        private List<UserStoryViewModel> _userStories = null;

        protected override void AssignRelevantPropertiesToViewModel(Backlog model)
        {
            //_viewModel.UserStories = _userStories ?? new UserStoryConverter().ToViewModels(model.UserStories);
        }

        protected override void InstantiateViewModel(Backlog model)
        {
            _viewModel = new BacklogViewModel()
            {
                BacklogId = model.BacklogId,
                ProjectId = model.Project.ProjectId,
                ProjectName = model.Project.Name,
                UserStoryIds = model.UserStories.Select(us => us.UserStoryId).ToList()
            };
        }

        protected override void FindRelevantProperties(params object[] viewModelProperties)
        {
            
        }
    }
}
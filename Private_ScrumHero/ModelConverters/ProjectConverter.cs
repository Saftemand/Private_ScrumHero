using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ModelConverters
{
    public class ProjectConverter : BaseConverter<ProjectViewModel, Project>
    {

        //TeamViewModel _team = null;

        protected override void AssignRelevantPropertiesToViewModel(Project model)
        {
            //_viewModel.Team = _team ?? new TeamConverter().ToViewModel(model.Team, _viewModel);
        }

        protected override void InstantiateViewModel(Project model)
        {
            _viewModel = new ProjectViewModel()
            {
                ProjectId = model.ProjectId,
                CreatedAt = model.CreatedAt,
                LastModifiedAt = model.LastModifiedAt,
                Name = model.Name,
                BacklogId = model.Backlog.BacklogId,
                TeamId = model.Team.TeamId
            };
        }

        protected override void FindRelevantProperties(params object[] viewModelProperties)
        {
            //foreach (IViewModel viewModel in viewModelProperties)
            //{
            //    if (viewModel.GetType() == typeof(TeamViewModel))
            //    {
            //        _team = viewModel as TeamViewModel;
            //    }
            //}
        }
    }
}
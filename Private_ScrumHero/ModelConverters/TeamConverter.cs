using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ModelConverters
{
    public class TeamConverter : BaseConverter<TeamViewModel, Team>
    {
        //private ProjectViewModel _project = null;
        //private List<TeamUserRoleViewModel> _teamUserRoles = null;

        protected override void AssignRelevantPropertiesToViewModel(Team model)
        {
            //_viewModel.Project = _project ?? new ProjectConverter().ToViewModel(model.Project, _viewModel);
            //_viewModel.TeamUserRoles = _teamUserRoles ?? new TeamUserRoleConverter().ToViewModels(model.TeamUserRoles, _viewModel);
        }

        protected override void InstantiateViewModel(Team model)
        {
            _viewModel = new TeamViewModel()
            {
                TeamId = model.TeamId,
                TeamName = model.TeamName,
                ProjectId = model.Project.ProjectId,
                TeamUserRoleIds = model.TeamUserRoles.Select(tur => tur.TeamUserRoleId).ToList()
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
            //    if (viewModel.GetType() == typeof(List<TeamUserRoleViewModel>))
            //    {
            //        _teamUserRoles = viewModel as List<TeamUserRoleViewModel>;
            //    }
            //}
        }
    }
}
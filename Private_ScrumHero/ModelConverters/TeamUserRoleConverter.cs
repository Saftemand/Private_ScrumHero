using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ModelConverters
{
    public class TeamUserRoleConverter : BaseConverter<TeamUserRoleViewModel, TeamUserRole>
    {
        //TeamViewModel _team = null;
        //ApplicationUserViewModel _user = null;

        private List<ApplicationUser> _tempApplicationUsers = new List<ApplicationUser>();

        protected override void AssignRelevantPropertiesToViewModel(TeamUserRole model)
        {
            //_viewModel.Team = _team ?? new TeamConverter().ToViewModel(model.Team);
            //_viewModel.User = _user ?? new ApplicationUserConverter().ToViewModel(model.User, _viewModel);
        }

        protected override void InstantiateViewModel(TeamUserRole model)
        {
            TeamUserRoleViewModel teamUserRoleViewModel = new TeamUserRoleViewModel()
            {
                TeamUserRoleId = model.TeamUserRoleId,
                Role = model.Role,
                TeamId = model.Team.TeamId,
                UserId = model.User.Id
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
            //    if (viewModel.GetType() == typeof(ApplicationUserViewModel))
            //    {
            //        _user = viewModel as ApplicationUserViewModel;
            //    }
            //}
        }
    }
}
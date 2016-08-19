using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.Models;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ModelConverters
{
    public class ApplicationUserConverter : BaseConverter<ApplicationUserViewModel, ApplicationUser>
    {

        //private List<TeamViewModel> _teams = null;

        protected override void InstantiateViewModel(ApplicationUser model)
        {
            _viewModel = new ApplicationUserViewModel()
            {
                ApplicationUserId = model.Id,
                Email = model.Email,
                UserName = model.UserName,
                TeamIds = model.Teams.Select(t => t.TeamId).ToList()
            };
        }

        protected override void FindRelevantProperties(params object[] viewModelProperties)
        {
            //foreach (IViewModel viewModel in viewModelProperties)
            //{
            //    if (viewModel.GetType() == typeof(List<TeamViewModel>))
            //    {
            //        _teams = viewModel as List<TeamViewModel>;
            //    }
            //    if (viewModel.GetType() == typeof(TeamViewModel))
            //    {
            //        _teams = new List<TeamViewModel>() { viewModel as TeamViewModel };
            //    }
            //}
        }

        protected override void AssignRelevantPropertiesToViewModel(ApplicationUser model)
        {
            //_viewModel.Teams = _teams ?? new TeamConverter().ToViewModels(model.Teams);
        }

    }
}
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
    public class TeamService
    {
        public static TeamViewModel FindById(int teamId)
        {
            TeamViewModel viewModel = null;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                viewModel = new TeamConverter().ToViewModel(context.Teams.Include(t => t.TeamUserRoles).Include(t => t.Project).FirstOrDefault(t => t.TeamId == teamId));
            }
            return viewModel;
        }
    }
}
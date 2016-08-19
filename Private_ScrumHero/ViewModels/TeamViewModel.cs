using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.ViewModels
{
    public class TeamViewModel : IViewModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public List<int> TeamUserRoleIds { get; set; }

        public int ProjectId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero;

namespace Private_ScrumHero.ViewModels
{
    public class TeamUserRoleViewModel : IViewModel
    {
        public int TeamUserRoleId { get; set; }

        public int TeamId { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.ModelConverters;

namespace Private_ScrumHero.ViewModels
{
    public class ApplicationUserViewModel : IViewModel
    {
        public string ApplicationUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<int> TeamIds { get; set; }

    }
}
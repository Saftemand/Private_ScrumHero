using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Private_ScrumHero.ViewModels
{
    public class ReleaseViewModel : IViewModel
    {
        public int ReleaseId { get; set; }
        public string ReleaseName { get; set; }

        public List<int> SprintIds { get; set; }
        public List<int> UserStoryIds { get; set; }

        public int ProjectId { get; set; }
    }
}

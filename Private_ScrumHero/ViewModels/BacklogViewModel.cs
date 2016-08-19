using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.Models;

namespace Private_ScrumHero.ViewModels
{
    public class BacklogViewModel : IViewModel
    {
        public int BacklogId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<int> UserStoryIds { get; set; }

        public List<UserStoryViewModel> userStories { get; set; }
    }
}
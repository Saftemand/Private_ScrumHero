using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Private_ScrumHero.ViewModels
{
    public class UserStoryViewModel : IViewModel
    {
        public int UserStoryId { get; set; }
        public string LocalId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }

        public List<int> DeveloperTaskIds { get; set; }

        public int BacklogId { get; set; }

        public int SprintId { get; set; }

        public int ReleaseId { get; set; }

        public BacklogViewModel Backlog { get; set; }

        public List<DeveloperTaskViewModel> DeveloperTasks { get; set; }
    }
}
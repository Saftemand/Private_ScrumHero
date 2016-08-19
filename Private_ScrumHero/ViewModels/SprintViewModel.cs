using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Private_ScrumHero.ViewModels
{
    public class SprintViewModel : IViewModel
    {
        public int SprintId { get; set; }
        public int localId { get; set; }
        public string SprintName { get; set; }

        public List<int> UserStoryIds { get; set; }

        public int ReleaseId { get; set; }
    }
}

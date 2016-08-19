using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Private_ScrumHero.Models;

namespace Private_ScrumHero.ViewModels
{
    public class DeveloperTaskViewModel : IViewModel
    {
        public int DeveloperTaskId { get; set; }
        public int LocalId { get; set; }
        public string DeveloperTaskName { get; set; }
        public int UserStoryId { get; set; }
    }
}

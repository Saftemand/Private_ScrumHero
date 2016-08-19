using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Private_ScrumHero.ModelConverters;
using Private_ScrumHero.Models;

namespace Private_ScrumHero.ViewModels
{
    public class ProjectViewModel : IViewModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public int BacklogId { get; set; }
        public int TeamId { get; set; }

        public TeamViewModel Team { get; set; }
    }
}
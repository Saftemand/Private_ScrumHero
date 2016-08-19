using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Private_ScrumHero.Models
{
    public class UserStory : IModel
    {
        public int UserStoryId { get; set; }
        public string LocalId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }

        public virtual List<DeveloperTask> DeveloperTasks { get; set; }

        [Required]
        public Backlog Backlog { get; set; }

        public virtual Sprint Sprint { get; set; }

        public virtual Release Release { get; set; }
    }
}
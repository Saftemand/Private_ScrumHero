using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Private_ScrumHero.Models
{
    public class Sprint : IModel
    {
        public int SprintId { get; set; }
        public int localId { get; set; }
        public string SprintName { get; set; }

        public List<UserStory> UserStories { get; set; }

        [Required]
        public Release Release { get; set; }
    }
}
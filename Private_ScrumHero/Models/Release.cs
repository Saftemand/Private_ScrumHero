using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Private_ScrumHero.Models
{
    public class Release : IModel
    {
        public int ReleaseId { get; set; }
        public string ReleaseName { get; set; }

        public List<Sprint> Sprints { get; set; }
        public List<UserStory> UserStories { get; set; }

        [Required]
        public Project Project { get; set; }
    }
}
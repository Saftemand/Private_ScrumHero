using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Private_ScrumHero.Models
{
    public class DeveloperTask : IModel
    {
        public int DeveloperTaskId { get; set; }
        public int LocalId { get; set; }
        public string DeveloperTaskName { get; set; }

        [Required]
        public UserStory UserStory { get; set; }
    }
}
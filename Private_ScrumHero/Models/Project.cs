using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Private_ScrumHero.Models
{
    public class Project : IModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }

        
        public Backlog Backlog { get; set; }
        public Team Team { get; set; }
        public virtual List<Release> Releases { get; set; }
    }
}
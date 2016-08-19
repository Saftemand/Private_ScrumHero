using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Private_ScrumHero.Models
{
    public class Team : IModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public List<TeamUserRole> TeamUserRoles { get; set; }

        [Required]
        public Project Project { get; set; }
    }
}
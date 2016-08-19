using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Private_ScrumHero.Models
{
    public class TeamUserRole : IModel
    {
        public int TeamUserRoleId { get; set; }
        
        [Required]
        public Team Team { get; set; }
        public ApplicationUser User { get; set; }
        public string Role { get; set; }
    }
}
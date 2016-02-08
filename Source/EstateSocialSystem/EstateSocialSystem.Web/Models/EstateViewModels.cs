using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstateSocialSystem.Web.Models
{
    public class EstateCreateViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Size")]
        public double Size { get; set; }
    }
}
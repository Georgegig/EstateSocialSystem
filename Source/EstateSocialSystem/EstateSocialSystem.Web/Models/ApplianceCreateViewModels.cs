﻿namespace EstateSocialSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ApplianceCreateViewModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public int Input { get; set; }

        [Required]
        public int Output { get; set; }
    }
}
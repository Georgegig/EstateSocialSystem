﻿namespace EstateSocialSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EstateDisplayViewModel : IMapFrom<Estate>
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Size")]
        public double Size { get; set; }

        public string EstateModel { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<EstateComment> Comments { get; set; }

        public IEnumerable<EstateRating> Ratings { get; set; }
    }
}
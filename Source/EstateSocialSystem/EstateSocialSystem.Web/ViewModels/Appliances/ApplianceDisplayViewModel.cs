namespace EstateSocialSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApplianceDisplayViewModel : IMapFrom<Appliance>
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Power")]
        public int Power { get; set; }

        [Display(Name = "Input")]
        public int Input { get; set; }

        [Display(Name = "Output")]
        public int Output { get; set; }

        public string ManufacturerId { get; set; }

        public IEnumerable<ApplianceComment> Comments { get; set; }

        public IEnumerable<ApplianceRating> Ratings { get; set; }
    }
}
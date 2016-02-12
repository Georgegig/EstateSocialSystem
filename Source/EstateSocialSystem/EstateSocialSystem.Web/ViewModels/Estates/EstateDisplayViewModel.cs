namespace EstateSocialSystem.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EstateDisplayViewModel
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
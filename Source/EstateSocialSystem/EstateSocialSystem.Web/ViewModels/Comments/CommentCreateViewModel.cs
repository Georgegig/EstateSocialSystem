namespace EstateSocialSystem.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CommentCreateViewModel
    {
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "EstateId")]
        public int EstateId { get; set; }
    }
}
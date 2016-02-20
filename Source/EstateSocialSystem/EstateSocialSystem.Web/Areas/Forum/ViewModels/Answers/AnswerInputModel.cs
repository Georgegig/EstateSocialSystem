namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class AnswerInputModel
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
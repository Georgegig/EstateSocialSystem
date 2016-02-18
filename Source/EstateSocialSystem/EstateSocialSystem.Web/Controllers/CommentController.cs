namespace EstateSocialSystem.Web.Controllers
{
    using Services.Data;
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;

    public class CommentController : Controller
    {
        private readonly IEstateCommentService estateComments;
        private readonly IApplianceCommentService applianceComments;

        public CommentController(IEstateCommentService estateComments, IApplianceCommentService applianceComments)
        {
            this.estateComments = estateComments;
            this.applianceComments = applianceComments;
        }

        // Post: Create EstateComment
        [HttpPost]
        [Authorize]
        public ActionResult CreateEstateComment(string content, int id)
        {
            var comment = new EstateComment
            {
                Content = content,
                AuthorId = User.Identity.GetUserId(),
                EstateId = id
            };

            this.estateComments.AddComment(comment);

            return this.RedirectToAction("Display", "Estate", new { id = id });
        }

        // Post: Create ApplianceComment
        [HttpPost]
        [Authorize]
        public ActionResult CreateApplianceComment(string content, int id)
        {
            var comment = new ApplianceComment
            {
                Content = content,
                AuthorId = User.Identity.GetUserId(),
                ApplianceId = id
            };

            this.applianceComments.AddComment(comment);

            return this.RedirectToAction("Display", "Appliance", new { id = id });
        }
    }
}
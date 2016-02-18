namespace EstateSocialSystem.Web.Controllers
{
    using Services.Data;
    using System.Web.Mvc;
    using Data.Models;
    using Models;
    using Microsoft.AspNet.Identity;

    public class CommentController : Controller
    {
        private readonly IEstateCommentService comments;

        public CommentController(IEstateCommentService comments)
        {
            this.comments = comments;
        }

        // Post: Create Comment
        [HttpPost]
        [Authorize]
        public ActionResult Create(string content, int id)
        {
            var comment = new EstateComment
            {
                Content = content,
                AuthorId = User.Identity.GetUserId(),
                EstateId = id
            };

            this.comments.AddComment(comment);

            return this.RedirectToAction("Display", "Estate", new { id = id });
        }
    }
}
namespace EstateSocialSystem.Web.Controllers
{
    using Services.Data;
    using System.Web.Mvc;
    using Data.Models;
    using Models;
    using Microsoft.AspNet.Identity;

    public class CommentController : Controller
    {
        private readonly ICommentService comments;

        public CommentController(ICommentService comments)
        {
            this.comments = comments;
        }

        // Post: Create Comment
        [HttpPost]
        [Authorize]
        public ActionResult Create(string content, int id)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    Content = content,
                    AuthorId = User.Identity.GetUserId(),
                    EstateId = id
                };

                this.comments.AddComment(comment);

                return this.RedirectToAction("Display", "Estate", new  { id = id });
            }

            return this.RedirectToAction("Display", "Estate", new { id = id });
        }
    }
}
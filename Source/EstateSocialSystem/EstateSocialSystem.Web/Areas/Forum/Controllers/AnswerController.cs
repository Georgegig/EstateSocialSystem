namespace EstateSocialSystem.Web.Areas.Forum.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using System.Web.Mvc;
    using ViewModels;

    public class AnswerController : Controller
    {
        private readonly IDeletableEntityRepository<Answer> answers;

        public AnswerController(IDeletableEntityRepository<Answer> answers)
        {
            this.answers = answers;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnswerInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var feedback = new Answer()
            {
                Content = model.Content,
                Title = model.Title
            };

            if (this.User.Identity.IsAuthenticated)
            {
                feedback.AuthorId = this.User.Identity.GetUserId();
            }

            this.answers.Add(feedback);
            this.answers.SaveChanges();

            this.TempData["Notification"] = "Thank you for your answer!";
            return this.Redirect("/");
        }
    }
}
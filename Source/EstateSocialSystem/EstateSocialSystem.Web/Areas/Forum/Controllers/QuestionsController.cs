﻿namespace EstateSocialSystem.Web.Areas.Forum.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using Infrastructure.Mapping;
    using Infrastructure;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels;
    using InputModels;
    using Microsoft.AspNet.Identity;

    public class QuestionsController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;

        private readonly ISanitizer sanitizer;

        public QuestionsController(IDeletableEntityRepository<Post> posts, ISanitizer sanitizer)
        {
            this.posts = posts;
            this.sanitizer = sanitizer;
        }

        // /questions/26864653/mysql-workbench-crash-on-start-on-windows
        public ActionResult Display(int id, string url, int page = 1)
        {
            var question = this.posts.All().Where(x => x.Id == id).To<QuestionViewModel>().FirstOrDefault();

            if (question == null)
            {
                return this.HttpNotFound("No such post");
            }
            var viewModel = new QuestionDisplayViewModel
            {
                Question = question,
                Answer = new AnswerInputModel()
                {
                    PostId = question.Id
                }
            };

            return this.View(viewModel);
        }

        // /questions/tagged/javascript
        public ActionResult GetByTag(string tag)
        {
            return this.Content(tag);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Ask()
        {
            var model = new AskInputModel();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Ask(AskInputModel input)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var post = new Post
                {
                    Title = input.Title,
                    Content = this.sanitizer.Sanitize(input.Content),
                    AuthorId = userId,

                    // TODO: Tags
                    // TODO: Author
                };

                this.posts.Add(post);
                this.posts.SaveChanges();
                return this.RedirectToAction("Display", new { id = post.Id, url = "new" });
            }

            return this.View(input);
        }
    }
}
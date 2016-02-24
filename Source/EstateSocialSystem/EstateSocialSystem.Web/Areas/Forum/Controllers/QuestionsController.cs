namespace EstateSocialSystem.Web.Areas.Forum.Controllers
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
    using System;

    public class QuestionsController : Controller
    {
        const int PostsPerPage = 5;
        const int AnswersPerPage = 5;
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly ISanitizer sanitizer;

        public QuestionsController(IDeletableEntityRepository<Post> posts, ISanitizer sanitizer)
        {
            this.posts = posts;
            this.sanitizer = sanitizer;
        }

        // /questions/26864653
        public ActionResult Display(int id, int page = 1)
        {
            var viewModel = new QuestionDisplayViewModel();

            var question = this.posts
                .All()
                .Where(x => x.Id == id)
                .To<QuestionViewModel>()
                .FirstOrDefault();

            if (question == null)
            {
                return this.HttpNotFound("No such post");
            }

            decimal totalPages = 0;
            var allAnswersCount = 0;

            if (question.Answers.Count() != 0)
            {
                allAnswersCount = question.Answers.Count();
                totalPages = Math.Ceiling(allAnswersCount / (decimal)AnswersPerPage);
                var itemsToSkip = (page - 1) * AnswersPerPage;
                var answers = question
                    .Answers
                    .AsQueryable()
                    .To<PostAnswerViewModel>()
                    .ToList()
                    .OrderByDescending(x => x.CreatedOn)
                    .Skip(itemsToSkip)
                    .Take(AnswersPerPage);


                viewModel.TotalPages = (int)totalPages;
                viewModel.CurrentPage = page;
                viewModel.Answers = answers;
            }

            viewModel.Question = question;
            viewModel.Answer = new AnswerInputModel()
            {
                PostId = question.Id
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
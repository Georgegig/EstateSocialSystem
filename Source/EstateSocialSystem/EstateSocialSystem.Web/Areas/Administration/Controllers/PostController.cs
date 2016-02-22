namespace EstateSocialSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Data.Models;
    using Data.Common.Repository;
    using Infrastructure.Mapping;
    using ViewModels;
    using Microsoft.AspNet.Identity;

    public class PostController : Controller
    {
        private IDeletableEntityRepository<Post> posts;

        public PostController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Posts_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.posts
                .All()
                .To<AdministerPostViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Create([DataSourceRequest]DataSourceRequest request, AdministerPostViewModel post)
        {
            var newId = 0;          

            if (ModelState.IsValid)
            {
                var entity = new Post
                {
                    Title = post.Title,
                    Content = post.Content,
                    AuthorId = this.User.Identity.GetUserId()
                };

                this.posts.Add(entity);
                this.posts.SaveChanges();
                newId = entity.Id;
            }
            var postToDisplay = this.posts
                .All()
                .To<AdministerPostViewModel>()
                .FirstOrDefault(x => x.Id == newId);

            return Json(new[] { postToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Update([DataSourceRequest]DataSourceRequest request, AdministerPostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var entity = this.posts.GetById(post.Id);
                entity.Title = post.Title;
                entity.Content = post.Content;
                this.posts.SaveChanges();
            }

            var postToDisplay = this.posts
                .All()
                .To<AdministerPostViewModel>()
                .FirstOrDefault(x => x.Id == post.Id);

            return Json(new[] { postToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Destroy([DataSourceRequest]DataSourceRequest request, Post post)
        {
            this.posts.Delete(post.Id);
            this.posts.SaveChanges();

            return Json(new[] { post }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.posts.Dispose();
            base.Dispose(disposing);
        }
    }
}

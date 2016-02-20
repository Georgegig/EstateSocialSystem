namespace EstateSocialSystem.Web.Areas.Forum.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using ViewModels;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public HomeController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            var model = this.posts.All().To<IndexBlogPostViewModel>();

            return this.View(model);
        }
    }
}
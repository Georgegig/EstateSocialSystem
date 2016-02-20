namespace EstateSocialSystem.Web.Areas.Forum.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using ViewModels;
    using System.Web.Mvc;
    using System;
    using System.Linq;
    using Infrastructure.Mapping;

    [Authorize]
    public class PageableAnswerListController : Controller
    {
        const int ItemsPerPage = 4;
        private readonly IDeletableEntityRepository<Answer> answers;

        public PageableAnswerListController(IDeletableEntityRepository<Answer> answers)
        {
            this.answers = answers;
        }

        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            AnswerListViewModel viewModel;
            if (this.HttpContext.Cache["Answer page_" + id] != null)
            {
                viewModel = (AnswerListViewModel)this.HttpContext.Cache["Answer page_" + id];
            }
            else
            {
                var page = id;
                var allItemsCount = this.answers.All().Count();
                var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
                var itemsToSkip = (page - 1) * ItemsPerPage;
                var Answers = this.answers.All()
                    .OrderBy(x => x.CreatedOn)
                    .ThenBy(x => x.Id)
                    .Skip(itemsToSkip)
                    .Take(ItemsPerPage)
                    .To<AnswerViewModel>().ToList();

                viewModel = new AnswerListViewModel()
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    Answers = Answers
                };

                this.HttpContext.Cache["Answer page_" + id] = viewModel;
            }

            return this.View(viewModel);
        }
    }
}
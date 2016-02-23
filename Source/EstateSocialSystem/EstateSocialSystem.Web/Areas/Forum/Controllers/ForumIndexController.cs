namespace EstateSocialSystem.Web.Areas.Forum.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using ViewModels;
    using System;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Collections.Generic;

    public class ForumIndexController : Controller
    {
        const int ItemsPerPage = 5;
        private readonly IPostService posts;

        public ForumIndexController(IPostService posts)
        {
            this.posts = posts;
        }

        public ActionResult Index(string sortBy = "date", int id = 1)
        {
            var page = id;
            var allItemsCount = this.posts.GetAll().Count();
            var totalPages = Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;

            var posts = this.posts
                .GetAll()
                .To<IndexBlogPostViewModel>()
                .ToList()
                .OrderByDescending(x => x, new PostSorterService(sortBy))
                .Skip(itemsToSkip)
                .Take(ItemsPerPage);

            var viewModel = new IndexListBlogPostViewModel
            {
                SortBy = sortBy,
                CurrentPage = page,
                TotalPages = (int)totalPages,
                Posts = posts
            };

            return View(viewModel);
        }

        #region Helpers
        public class PostSorterService : IComparer<IndexBlogPostViewModel>
        {
            private string sortBy;

            public PostSorterService(string sortBy)
            {
                this.sortBy = sortBy;
            }

            public int Compare(IndexBlogPostViewModel x, IndexBlogPostViewModel y)
            {
                if (this.sortBy == "date")
                {
                    return DateTime.Compare(x.CreatedOn, y.CreatedOn);
                }
                else if (this.sortBy == "vote")
                {
                    if (x.Votes.Count == 0 && y.Votes.Count != 0)
                    {
                        return -1;
                    }
                    else if (x.Votes.Count != 0 && y.Votes.Count == 0)
                    {
                        return 1;
                    }
                    else if (!(x.Votes.Count == 0) && !(y.Votes.Count == 0))
                    {
                        var xAverageRating = x.Votes.Count(v => v.Type == Data.Models.VoteType.Positive) - x.Votes.Count(v => v.Type == Data.Models.VoteType.Negative);
                        var yAverageRating = y.Votes.Count(v => v.Type == Data.Models.VoteType.Positive) - y.Votes.Count(v => v.Type == Data.Models.VoteType.Negative);

                        if (xAverageRating < yAverageRating)
                        {
                            return -1;
                        }
                        else if (xAverageRating > yAverageRating)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion
    }
}
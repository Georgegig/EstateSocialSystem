namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class IndexListBlogPostViewModel
    {
        public string SortBy { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public DateTime CreatedOn { get; set; }
 
        public IEnumerable<IndexBlogPostViewModel> Posts { get; set; }
    }
}
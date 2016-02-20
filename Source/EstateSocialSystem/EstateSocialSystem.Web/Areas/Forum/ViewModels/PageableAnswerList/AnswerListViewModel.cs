namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    using System.Collections.Generic;

    public class AnswerListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<AnswerViewModel> Answers { get; set; }
    }
}
using System.Collections.Generic;

namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    public class QuestionDisplayViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<PostAnswerViewModel> Answers { get; set; }

        public QuestionViewModel Question { get; set; }

        public AnswerInputModel Answer { get; set; }
    }
}
namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    using Data.Models;
    using Web.Infrastructure.Mapping;

    public class QuestionDisplayViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
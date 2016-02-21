namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class IndexBlogPostTagViewModel : IMapFrom<Tag>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
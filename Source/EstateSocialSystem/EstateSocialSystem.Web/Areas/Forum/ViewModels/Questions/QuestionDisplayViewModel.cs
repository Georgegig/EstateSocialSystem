namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    using Data.Models;
    using System;
    using Web.Infrastructure.Mapping;
    using AutoMapper;

    public class QuestionDisplayViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, QuestionDisplayViewModel>()
                .ForMember(x => x.Author,
                opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
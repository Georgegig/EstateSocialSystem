namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using AutoMapper;

    public class PostAnswerViewModel : IMapFrom<Answer>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Answer, PostAnswerViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
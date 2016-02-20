namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using AutoMapper;
    using Infrastructure;

    public class AnswerViewModel : IMapFrom<Answer>, IHaveCustomMappings
    {
        ISanitizer sanitizer;

        public AnswerViewModel()
        {
            sanitizer = new HtmlSanitizerAdapter();
        }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent
        {
            get
            {
                return this.sanitizer.Sanitize(this.Content);
            }
        }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Answer, AnswerViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
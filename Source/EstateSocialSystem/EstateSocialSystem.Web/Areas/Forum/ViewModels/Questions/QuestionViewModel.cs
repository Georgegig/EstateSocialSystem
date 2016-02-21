namespace EstateSocialSystem.Web.Areas.Forum.ViewModels
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;

    public class QuestionViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, QuestionViewModel>()
                .ForMember(x => x.Author,
                opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
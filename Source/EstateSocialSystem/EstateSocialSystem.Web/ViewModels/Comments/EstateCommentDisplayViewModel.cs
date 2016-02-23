namespace EstateSocialSystem.Web.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using AutoMapper;

    public class EstateCommentDisplayViewModel : IMapFrom<EstateComment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<EstateComment, EstateCommentDisplayViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
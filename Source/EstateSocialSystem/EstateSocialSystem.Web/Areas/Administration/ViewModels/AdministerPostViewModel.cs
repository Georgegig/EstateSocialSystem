namespace EstateSocialSystem.Web.Areas.Administration.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;

    public class AdministerPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, AdministerPostViewModel>().
               ForMember(x => x.AuthorName, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
namespace EstateSocialSystem.Web.Areas.Administration.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    public class AdministerEstateViewModel : IMapFrom<Estate>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        public double Size { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Estate, AdministerEstateViewModel>().
                ForMember(x => x.AuthorName, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
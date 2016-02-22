namespace EstateSocialSystem.Web.Areas.Administration.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;

    public class AdministerApplianceViewModel : IMapFrom<Appliance>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public int Input { get; set; }

        [Required]
        public int Output { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Appliance, AdministerApplianceViewModel>().
                ForMember(x => x.Manufacturer, opt => opt.MapFrom(x => x.Manufacturer.UserName));
        }
    }
}
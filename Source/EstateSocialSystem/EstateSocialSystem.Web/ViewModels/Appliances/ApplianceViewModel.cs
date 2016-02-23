namespace EstateSocialSystem.Web.Models
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;

    public class ApplianceViewModel : IMapFrom<Appliance>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Power { get; set; }

        public int Input { get; set; }

        public int Output { get; set; }

        public string Manufacturer { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<ApplianceRating> Ratings { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Appliance, ApplianceViewModel>()
                .ForMember(x => x.Manufacturer, opt => opt.MapFrom(x => x.Manufacturer.UserName));
        }
    }
}
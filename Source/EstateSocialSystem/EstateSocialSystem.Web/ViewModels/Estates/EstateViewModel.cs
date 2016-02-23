namespace EstateSocialSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using AutoMapper;
    using System.Collections.Generic;

    public class EstateViewModel : IMapFrom<Estate>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Size { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<EstateRating> Ratings { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Estate, EstateViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
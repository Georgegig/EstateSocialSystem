namespace EstateSocialSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;

    public class EstatePersonalViewModel : IMapFrom<Estate>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Size { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
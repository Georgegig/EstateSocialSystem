namespace EstateSocialSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;

    public class HomeIndexApplianceViewModel : IMapFrom<Appliance>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<ApplianceRating> Ratings { get; set; }
    }
}
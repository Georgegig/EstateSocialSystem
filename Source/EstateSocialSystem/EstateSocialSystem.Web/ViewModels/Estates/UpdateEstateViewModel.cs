namespace EstateSocialSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UpdateEstateViewModel : IMapFrom<Estate>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Size { get; set; }
    }
}
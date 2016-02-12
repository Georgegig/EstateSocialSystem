namespace EstateSocialSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class HomeIndexEstateViewModel : IMapFrom<Estate>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
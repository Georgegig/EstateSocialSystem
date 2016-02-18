namespace EstateSocialSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class HomeIndexApplianceViewModel : IMapFrom<Appliance>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
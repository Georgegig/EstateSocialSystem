namespace EstateSocialSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class HomeIndexApplianceViewModel : IMapFrom<Appliance>
    {
        public string Name { get; set; }
    }
}
namespace EstateSocialSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UpdateApplianceViewModel : IMapFrom<Appliance>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Power { get; set; }

        public int Input { get; set; }

        public int Output { get; set; }

        public string ManufacturerId { get; set; }
    }
}
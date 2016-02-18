namespace EstateSocialSystem.Web.Models
{
    using System.Collections.Generic;

    public class AppliancePersonalListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<AppliancePersonalViewModel> Appliances { get; set; }
    }
}
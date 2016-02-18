namespace EstateSocialSystem.Web.Models
{
    using System.Collections.Generic;

    public class ApplianceListViewModel
    {

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ApplianceViewModel> Appliances { get; set; }
    }
}
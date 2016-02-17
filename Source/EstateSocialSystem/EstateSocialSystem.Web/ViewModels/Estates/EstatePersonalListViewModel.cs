namespace EstateSocialSystem.Web.Models
{
    using System.Collections.Generic;

    public class EstatePersonalListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<EstatePersonalViewModel> Estates { get; set; }
    }
}
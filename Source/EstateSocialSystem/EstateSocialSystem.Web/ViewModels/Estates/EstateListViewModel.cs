namespace EstateSocialSystem.Web.Models
{
    using System.Collections.Generic;

    public class EstateListViewModel 
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<EstateViewModel> Estates { get; set; }
    }
}
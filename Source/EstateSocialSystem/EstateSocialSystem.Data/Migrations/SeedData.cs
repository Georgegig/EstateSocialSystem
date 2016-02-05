namespace EstateSocialSystem.Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SeedData
    {
        public static Random Rand = new Random();
        
        public User Author { get; set; }

        public SeedData(User author)
        {

        }
    }
}

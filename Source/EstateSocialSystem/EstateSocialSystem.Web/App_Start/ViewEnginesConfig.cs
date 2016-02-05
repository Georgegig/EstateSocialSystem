namespace EstateSocialSystem.Web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ViewEnginesConfig
    {
        public static void RegisterEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
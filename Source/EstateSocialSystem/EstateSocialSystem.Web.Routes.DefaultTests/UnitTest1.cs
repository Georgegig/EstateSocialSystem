using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteUnitTester;

namespace EstateSocialSystem.Web.Routes.DefaultTests
{
    [TestClass]
    public class EstateRoutes
    {
        [TestMethod]
        public void TestRouteById()
        {
            var tester = new RouteTester<MvcApplication>();
            tester.WithIncomingRequest("/").ShouldMatchRoute("Home", "Index");            
        }
    }
}

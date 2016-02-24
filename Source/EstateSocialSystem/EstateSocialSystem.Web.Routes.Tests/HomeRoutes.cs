namespace EstateSocialSystem.Web.Routes.Tests
{
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;
    using System.Web.Routing;

    [TestFixture]
    public class HomeRoutes
    {
        [Test]
        public void TestIndexRoute()
        {
            var routeCollection = new RouteCollection();
            const string url = "/home/index";
            RouteConfig.RegisterRoutes(routeCollection);
            RouteAssert.HasRoute(routeCollection, "/home/index");
        }

        [Test]
        public void TestIndexRouteMapping()
        {
            var routeCollection = new RouteCollection();
            const string url = "/home/index";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url)
                .To<HomeController>(c => c.Index());
        }
    }
}

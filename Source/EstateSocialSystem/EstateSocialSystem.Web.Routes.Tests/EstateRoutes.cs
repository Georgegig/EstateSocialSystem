namespace EstateSocialSystem.Web.Routes.Tests
{
    using Controllers;
    using System.Web.Routing;
    using NUnit.Framework;
    using MvcRouteTester;

    [TestFixture]
    public class EstateRoutes
    {
        [Test]
        public void TestRouteById()
        {
            var routeCollection = new RouteCollection();
            const string url = "/estate/display/1?page=1";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url)
                .To<EstateController>(c => c.Display(1,1));
        }
    }
}

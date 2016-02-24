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
        public void TestDisplayById()
        {
            var routeCollection = new RouteCollection();
            const string url = "/estate/display/1?page=1";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url)
                .To<EstateController>(c => c.Display(1,1));
        }

        [Test]
        public void TestViewAllSortByDate()
        {
            var routeCollection = new RouteCollection();
            const string url = "/estate/viewAll/1?sortBy=date";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url)
                .To<EstateController>(c => c.ViewAll("date", 1));
        }

        [Test]
        public void TestViewAllSortByRating()
        {
            var routeCollection = new RouteCollection();
            const string url = "/estate/viewAll/1?sortBy=rating";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url)
                .To<EstateController>(c => c.ViewAll("rating", 1));
        }

        [Test]
        public void TestDeleteById()
        {
            var routeCollection = new RouteCollection();
            const string url = "/estate/delete/1";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url)
                .To<EstateController>(c => c.Delete(1));
        }

        [Test]
        public void TestUpdateById()
        {
            var routeCollection = new RouteCollection();
            const string url = "/estate/update/1";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url)
                .To<EstateController>(c => c.Update(1));
        }

        [Test]
        public void TestUpdateModelById()
        {
            var routeCollection = new RouteCollection();
            const string url = "/estate/updateModel/1?json=asd";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url)
                .To<EstateController>(c => c.UpdateModel("asd",1));
        }
    }
}

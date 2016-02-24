namespace EstateSocialSystem.Web.Routes.Tests
{
    using Areas.Forum.Controllers;
    using Areas.Forum;
    using MvcRouteTester;
    using NUnit.Framework;
    using System.Web.Routing;
    using System.Web.Mvc;

    [TestFixture]
    public class QuestionRoutes
    {
        [Test]
        public void TestRouteById()
        {
            var routeCollection = new RouteCollection();
            var forumAreaRegistration = new ForumAreaRegistration();
            var context = new AreaRegistrationContext(forumAreaRegistration.AreaName, routeCollection);
            const string url = "/questions/26?page=1";
            forumAreaRegistration.RegisterArea(context);
            routeCollection.ShouldMap(url)
                .To<QuestionsController>(c => c.Display(26,1));            
        }
    }
}

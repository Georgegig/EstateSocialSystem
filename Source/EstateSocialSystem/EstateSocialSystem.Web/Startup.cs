using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EstateSocialSystem.Web.Startup))]
namespace EstateSocialSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

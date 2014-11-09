using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Falcon.Web.Startup))]
namespace Falcon.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

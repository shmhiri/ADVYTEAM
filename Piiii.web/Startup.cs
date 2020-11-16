using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Piiii.web.Startup))]
namespace Piiii.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

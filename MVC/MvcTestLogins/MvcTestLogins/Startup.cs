using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcTestLogins.Startup))]
namespace MvcTestLogins
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

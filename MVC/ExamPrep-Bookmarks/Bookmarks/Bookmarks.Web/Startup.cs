using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookmarks.Web.Startup))]
namespace Bookmarks.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

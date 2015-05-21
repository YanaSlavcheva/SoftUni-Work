using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterLikeApp.Web.Startup))]
namespace TwitterLikeApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

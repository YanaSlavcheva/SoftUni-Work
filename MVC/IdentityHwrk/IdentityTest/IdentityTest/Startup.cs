using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityTest.Startup))]
namespace IdentityTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

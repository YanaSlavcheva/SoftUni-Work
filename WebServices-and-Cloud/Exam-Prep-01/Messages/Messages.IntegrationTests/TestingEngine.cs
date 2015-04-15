namespace Messages.IntegrationTests
{
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;

    using EntityFramework.Extensions;

    using Messages.Data;

    using MessagesRestService;

    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Owin;

    [TestClass]
    public static class TestingEngine
    {
        private static TestServer TestWebServer { get; set; }

        public static HttpClient HttpClient { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Start OWIN testing HTTP server with Web API support
            TestWebServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var webAppStartup = new Startup();
                webAppStartup.Configuration(appBuilder);
                appBuilder.UseWebApi(config);
            });
            HttpClient = TestWebServer.HttpClient;
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            TestWebServer.Dispose();
        }

        public static void CleanDatabase()
        {
            using (var dbContext = new MessagesDbContext())
            {
                dbContext.ChannelMessages.Delete();
                dbContext.UserMessages.Delete();
                dbContext.Users.Delete();
                dbContext.Channels.Delete();
                dbContext.SaveChanges();
            }
        }

        public static int GetChannelsCountFromDb()
        {
            using (var dbContext = new MessagesDbContext())
            {
                return dbContext.Channels.Count();
            }
        }
    }
}

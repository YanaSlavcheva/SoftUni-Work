namespace Bookmarks.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Bookmarks.Data;
    using Bookmarks.Web.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var bookmarks = this.Data.Bookmarks.All().Project().To<BookmarkViewModel>();

            return this.View(bookmarks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
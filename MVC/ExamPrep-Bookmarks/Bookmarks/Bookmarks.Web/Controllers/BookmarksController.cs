using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookmarks.Web.Controllers
{
    public class BookmarksController : Controller
    {
        // GET: Bookmarks
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
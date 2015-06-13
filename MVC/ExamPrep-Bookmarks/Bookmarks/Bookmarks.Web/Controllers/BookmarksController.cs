namespace Bookmarks.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Bookmarks.Common;
    using Bookmarks.Data;
    using Bookmarks.Web.ViewModels;

    using PagedList;

    public class BookmarksController : BaseController
    {
        // GET: Bookmarks
        public BookmarksController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Index(int? page)
        {
            var bookmarks = this.Data.Bookmarks
                .All()
                .OrderBy(b => b.Title)
                .Project()
                .To<BookmarkViewModel>()
                .ToPagedList(page ?? GlobalConstants.BookmarksIndexDefaultPageNumber, GlobalConstants.BookmarksIndexNumberOfBookmarksPerPage);

            return View(bookmarks);
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
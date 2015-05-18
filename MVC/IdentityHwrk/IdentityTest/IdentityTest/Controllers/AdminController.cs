namespace IdentityTest.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            if (this.User.IsInRole("Administrator"))
            {
                return this.View(model: this.User.Identity.GetUserName());
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
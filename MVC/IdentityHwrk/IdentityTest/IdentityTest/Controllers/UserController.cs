namespace IdentityTest.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    public class UserController : Controller
    {
        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.View(model: this.User.Identity.GetUserName());
            }

            return this.RedirectToAction("Register", "Account");
        }
    }
}
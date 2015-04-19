namespace BugTracker.RestServices.Controllers
{
    using System.Web.Http;

    using BugTracker.Data;

    public abstract class BaseApiController : ApiController
    {
        private BugTrackerDbContext data;

        protected BaseApiController(BugTrackerDbContext data)
        {
            this.data = data;
        }

        protected BaseApiController()
            : this(new BugTrackerDbContext())
        {
        }

        protected BugTrackerDbContext Data
        {
            get
            {
                return this.data;
            }

            private set
            {
                this.data = value;
            }
        }
    }
}
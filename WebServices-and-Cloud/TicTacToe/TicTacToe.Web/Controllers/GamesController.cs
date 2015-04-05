namespace TicTacToe.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using TicTacToe.Data;

    [Authorize]
    public class GamesController : ApiController
    {
        private ITicTacToeData data;

        public GamesController() : this(new TicTacToeData(new TicTacToeDbContext()))
        {
        }

        public GamesController(ITicTacToeData data)
        {
            this.data = data;
        }

        public IHttpActionResult GetUsersCount()
        {
            var count = this.data.Users.All().Count();
            return this.Ok(count);
        }
    }
}
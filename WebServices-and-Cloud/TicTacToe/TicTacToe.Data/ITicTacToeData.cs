namespace TicTacToe.Data
{
    using TicTacToe.Data.Repositories;
    using TicTacToe.Models;
    using TicTacToe.Web.Models;

    public interface ITicTacToeData
    {
        IRepository<TicTacToeUser> Users { get; }

        IRepository<Game> Games { get; }

        int SaveChanges();
    }
}

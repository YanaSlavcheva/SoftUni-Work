namespace TicTacToe.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNet.Identity;
    using Microsoft.VisualBasic.ApplicationServices;

    using TicTacToe.Web.Models;

    public class Game
    {
        public Game()
        {
            this.Id = Guid.NewGuid();
            this.Board = "---------";
            this.State = GameState.WaitingForSecondPlayer;
        }

        public Guid Id { get; set; }

        [StringLength(9)]
        [Column(TypeName = "char")]
        public string Board { get; set; }

        public GameState State { get; set; }

        [Column(TypeName = "nvarchar")]
        public string FirstPlayerId { get; set; }

        [Required]
        public virtual TicTacToeUser FirstPlayer { get; set; }

        public string SecondPlayerId { get; set; }

        public virtual TicTacToeUser SecondPlayer { get; set; }

    }
}

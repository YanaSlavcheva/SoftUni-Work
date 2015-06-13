namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public int Value { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual Bookmarks.Models.User User { get; set; }

        public int BookmarkId { get; set; }

        public virtual Bookmark Bookmark { get; set; }
    }
}

namespace Bookmarks.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Bookmark
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Bookmark()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
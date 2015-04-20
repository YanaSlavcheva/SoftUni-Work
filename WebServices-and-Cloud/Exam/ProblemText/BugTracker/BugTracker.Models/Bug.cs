namespace BugTracker.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        private ICollection<Comment> comments;
 
        public Bug()
        {
            this.DateCreated = DateTime.Now;
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus Status { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public DateTime DateCreated { get; set; }

        private ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}

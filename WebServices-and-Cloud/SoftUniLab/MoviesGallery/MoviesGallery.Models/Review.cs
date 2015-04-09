namespace MoviesGallery.Models
{
    using System;

    public class Review
    {
        public Review()
        {
            this.DateOfCreation = DateTime.Now;
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public DateTime DateOfCreation { get; set; }

        public virtual User User { get; set; }

        public string MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public string Content { get; set; }
    }
}

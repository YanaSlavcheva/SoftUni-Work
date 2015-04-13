namespace MoviesGallery.Models
{
    using System;

    public class Review
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
            this.DateOfCreation = DateTime.Now;
        }

        public string Id { get; set; }

        public DateTime DateOfCreation { get; private set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public string Content { get; set; }
    }
}

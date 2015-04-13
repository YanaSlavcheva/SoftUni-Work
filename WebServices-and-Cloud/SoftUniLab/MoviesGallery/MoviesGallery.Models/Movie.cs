namespace MoviesGallery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        private ICollection<Actor> actors;

        private ICollection<Review> reviews;

        public Movie()
        {
            this.Id = Guid.NewGuid().ToString();
            this.actors = new HashSet<Actor>();
            this.reviews = new HashSet<Review>();
        }

        // country, collection of actors and collection of reviews, genre
        public string Id { get; set; }

        public string Title { get; set; }

        public int Length { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Actor> Actors
        {
            get
            {
                return this.actors;
            }

            set
            {
                this.actors = value;
            }
        }

        public virtual ICollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
            }
        }

        public string GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}

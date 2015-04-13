namespace MoviesGallery.Models
{
    using System;
    using System.Collections.Generic;

    public class Actor
    {
        private ICollection<Movie> movies;

        public Actor()
        {
            this.movies = new HashSet<Movie>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Biography { get; set; }

        public string HomeTown { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get
            {
                return this.movies;
            }

            set
            {
                this.movies = value;
            }
        }
    }
}

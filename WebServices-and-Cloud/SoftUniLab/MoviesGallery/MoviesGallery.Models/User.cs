namespace MoviesGallery.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Win32;

    public class User : IdentityUser
    {
        private ICollection<Movie> favoriteMovies;

        private ICollection<Actor> favoriteActors;

        private ICollection<Review> reviews; 

        public User()
        {
            this.favoriteMovies = new HashSet<Movie>();
            this.favoriteActors = new HashSet<Actor>();
            this.reviews = new HashSet<Review>();
        }

        public string WebPage { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<Movie> FavoriteMovies
        {
            get
            {
                return this.favoriteMovies;
            }

            set
            {
                this.favoriteMovies = value;
            }
        }

        public virtual ICollection<Actor> FavoriteActors
        {
            get
            {
                return this.favoriteActors;
            }

            set
            {
                this.favoriteActors = value;
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}

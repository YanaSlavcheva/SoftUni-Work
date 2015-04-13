namespace MoviesGallery.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using MoviesGallery.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesGalleryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MoviesGalleryDbContext context)
        {
            // GENRES
            context.Genres.Add(new Genre { Name = "Action" });
            context.Genres.Add(new Genre { Name = "Romance" });
            context.Genres.Add(new Genre { Name = "Adventure" });
            context.Genres.Add(new Genre { Name = "Comedy" });
            context.SaveChanges();
            var genres = context.Genres;

            // MOVIES
            context.Movies.Add(
                  new Movie
                  {
                      Title = "Divergent",
                      Length = 139,
                      Rating = 7,
                      Country = "United States",
                      Genre = genres.FirstOrDefault(g => g.Name == "Adventure")
                  });
            context.Movies.Add(
                  new Movie
                  {
                      Title = "The Fault in Our Stars",
                      Length = 129,
                      Rating = 8,
                      Country = "United States",
                      Genre = genres.FirstOrDefault(g => g.Name == "Romance")
                  });
            context.Movies.Add(
                  new Movie
                  {
                      Title = "Marley & Me",
                      Length = 115,
                      Rating = 7,
                      Country = "United States",
                      Genre = genres.FirstOrDefault(g => g.Name == "Comedy")
                  });
            context.Movies.Add(
                  new Movie
                  {
                      Title = "Bruce Almighty",
                      Length = 101,
                      Rating = 7,
                      Country = "United States",
                      Genre = genres.FirstOrDefault(g => g.Name == "Comedy")
                  });
            context.SaveChanges();
            var movies = context.Movies;

            // ACTORS
            context.Actors.Add(
                new Actor
                {
                    Name = "Jennifer Aniston",
                    BirthDate = new DateTime(1969, 2, 11),
                    Biography =
                        "Jennifer Aniston was born in Sherman Oaks, California, to actors John Aniston and Nancy Dow.",
                    HomeTown = "Sherman Oaks",
                    Movies = new List<Movie>
                             {
                                 movies.FirstOrDefault(m => m.Title == "Marley & Me"),
                                 movies.FirstOrDefault(m => m.Title == "Bruce Almighty")
                             }
                });
            context.Actors.Add(
                new Actor
                {
                    Name = "Jim Carrey",
                    BirthDate = new DateTime(1962, 1, 17),
                    Biography =
                        "Jim Carrey, Canadian-born and a U.S. citizen since 2004, is an actor and producer famous for his rubbery body movements and flexible facial expressions.",
                    HomeTown = "Newmarket",
                    Movies = new List<Movie>
                             {
                                 movies.FirstOrDefault(m => m.Title == "Bruce Almighty")
                             }
                });
            context.Actors.Add(
                new Actor
                {
                    Name = "Shailene Woodley",
                    BirthDate = new DateTime(1991, 11, 15),
                    Biography =
                        "Actress Shailene Woodley was born in Simi Valley, California, to Lori (Victor), a middle school counselor, and Lonnie Woodley, a school principal.",
                    HomeTown = "Simi Valley",
                    Movies = new List<Movie>
                             {
                                 movies.FirstOrDefault(m => m.Title == "Divergent"),
                                 movies.FirstOrDefault(m => m.Title == "The Fault in Our Stars")
                             }
                });
            context.Actors.Add(
                new Actor
                {
                    Name = "Theo James",
                    BirthDate = new DateTime(1984, 12, 16),
                    Biography =
                        "Theo James was born on December 16, 1984 in Oxford, Oxfordshire, England as Theodore Peter James Kinnaird Taptiklis.",
                    HomeTown = "Oxford",
                    Movies = new List<Movie>
                             {
                                 movies.FirstOrDefault(m => m.Title == "Divergent")
                             }
                });

            // REVIEWS
            context.Reviews.Add(
                new Review
                {
                    Content = "Great movie!",
                    Movie = movies.FirstOrDefault(m => m.Title == "Divergent")
                });
            context.Reviews.Add(
                new Review
                {
                    Content = "I loved it. Did you?",
                    Movie = movies.FirstOrDefault(m => m.Title == "Marley & Me")
                });

            context.SaveChanges();
        }
    }
}

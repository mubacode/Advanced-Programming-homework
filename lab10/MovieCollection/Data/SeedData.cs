using Microsoft.EntityFrameworkCore;
using MovieCollection.Models;

namespace MovieCollection.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "The Shawshank Redemption",
                        ReleaseDate = DateTime.Parse("1994-10-14"),
                        Genre = "Drama",
                        Price = 9.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "The Godfather",
                        ReleaseDate = DateTime.Parse("1972-03-24"),
                        Genre = "Crime",
                        Price = 9.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Inception",
                        ReleaseDate = DateTime.Parse("2010-07-16"),
                        Genre = "Sci-Fi",
                        Price = 12.99M,
                        Rating = "PG-13"
                    }
                );
                context.SaveChanges();
            }
        }
    }
} 
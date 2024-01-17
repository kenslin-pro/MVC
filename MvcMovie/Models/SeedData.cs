using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var context = new MvcMovieContext(
        serviceProvider.GetRequiredService<
            DbContextOptions<MvcMovieContext>>()))
    {
      // Look for any movies.
      if (context.Movie.Any())
      {
        return;   // DB has been seeded
      }
      context.Movie.AddRange(
          new Movie
          {
            Title = "When Harry Met Sally",
            ReleaseDate = DateTime.Parse("1989-2-12"),
            Genre = "Romantic Comedy",
            Price = 7.99M
          },
          new Movie
          {
            Title = "Ghostbusters ",
            ReleaseDate = DateTime.Parse("1984-3-13"),
            Genre = "Comedy",
            Rating = "R",
            Price = 8.99M
          },
          new Movie
          {
            Title = "Ghostbusters 2",
            ReleaseDate = DateTime.Parse("1986-2-23"),
            Genre = "Comedy",
            Price = 9.99M
          },
          new Movie
          {
            Title = "Rio Bravo",
            ReleaseDate = DateTime.Parse("1959-4-15"),
            Genre = "Western",
            Price = 3.99M
          },
          new Movie
          {
            Title = "The Godfather",
            ReleaseDate = DateTime.Parse("1972-3-24"),
            Genre = "Crime",
            Price = 4.49M
          },
new Movie
{
  Title = "Inception",
  ReleaseDate = DateTime.Parse("2010-7-8"),
  Genre = "Sci-Fi",
  Price = 5.99M
},
new Movie
{
  Title = "The Shawshank Redemption",
  ReleaseDate = DateTime.Parse("1994-9-23"),
  Genre = "Drama",
  Price = 4.99M
}



      );
      context.SaveChanges();
    }
  }
}
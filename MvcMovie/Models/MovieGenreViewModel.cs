using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Controllers
{
  public class MoviesController : Controller
  {
    private readonly MvcMovieContext _context;

    public MoviesController(MvcMovieContext context)
    {
      _context = context;
    }

    // GET: Movies
    public async Task<IActionResult> Index(string movieGenre, string searchString)
    {
      if (_context.Movie == null)
      {
        return Problem("Entity set 'MvcMovieContext.Movie' is null.");
      }

      // Use LINQ to get a list of genres.
      IQueryable<string> genreQuery = from m in _context.Movie
                                      orderby m.Genre
                                      select m.Genre;

      var movies = from m in _context.Movie
                   select m;

      if (!string.IsNullOrEmpty(searchString))
      {
        movies = movies.Where(s => s.Title.Contains(searchString));
      }

      if (!string.IsNullOrEmpty(movieGenre))
      {
        movies = movies.Where(x => x.Genre == movieGenre);
      }

      var movieGenreVM = new MovieGenreViewModel
      {
        Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
        Movies = await movies.ToListAsync(),
        MovieGenre = movieGenre,
        SearchString = searchString
      };

      return View(movieGenreVM);
    }

    // Other actions and methods in the MoviesController...
  }
}
public async Task<IActionResult> Index(string searchString, int? year)
{
    if (_context.Movie == null)
    {
        return Problem("Entity set 'MvcMovieContext.Movie' is null.");
    }

    var movies = from m in _context.Movie
                 select m;

    if (!String.IsNullOrEmpty(searchString))
    {
        movies = movies.Where(s => s.Title.Contains(searchString));
    }

    if (year.HasValue)
    {
        movies = movies.Where(m => m.ReleaseYear >= year);
    }

    return View(await movies.ToListAsync());
}

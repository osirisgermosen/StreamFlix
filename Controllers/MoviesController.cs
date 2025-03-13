using Microsoft.AspNetCore.Mvc;
using MovieMvcProject.Models;
using MovieMvcProject.Services;

namespace MovieMvcProject.Controllers
{
    public class MoviesController : Controller
    {
        public IMovieService _movieService { get; }

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public ActionResult Index()
        {
            List<Movie> movies = _movieService.GetList();

            return View(movies);
        }

        public JsonResult json_movies()
        {
            List<Movie> movies = _movieService.GetList();

            return Json(movies);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            List<Movie> movies = _movieService.Search(search);

            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (movie == null)
                return NotFound();

            movie.Active = true;

            _movieService.Create(movie);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieById(id);

            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            var movieEdit = _movieService.GetMovieById(movie.Id);

            if (movieEdit == null)
                return NotFound();

            movieEdit.Title = movie.Title;
            movieEdit.ReleaseDate = movie.ReleaseDate;
            movieEdit.Genre = movie.Genre;
            movieEdit.Year = movie.Year;
            movieEdit.Price = movie.Price;

            _movieService.Update(movieEdit);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);

            return View(movie);
        }

        [HttpPost]
        public ActionResult Delete(Movie movie)
        {
            var _movie = _movieService.GetMovieById(movie.Id);

            if (_movie == null)
                return NotFound();

            _movieService.Delete(_movie.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

    }
}

using moviewatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Diagnostics;


namespace moviewatch.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _moviecontext; 
        public MoviesController()
        {
           _moviecontext = new ApplicationDbContext();
        }
        // GET: Movies/Random
        public ActionResult MovieForm()
        {
            var genre = _moviecontext.Genre.ToList();
            var viewmodel = new MovieViewModel
            {
                genre = genre
            };
            return View(viewmodel);
        }
        protected override void Dispose(bool disposing)
        {
            _moviecontext.Dispose();
        }

        [HttpPost]
        [Authorize(Roles =Storemanager.ManageMovies)]
        public ActionResult Register(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var moviemodel = new MovieViewModel
                {
                    Movie = movie,
                    genre = _moviecontext.Genre.ToList()
                };
                return View("MovieForm", moviemodel);
            }
            if (movie.Id == 0)
            {
                _moviecontext.Movies.Add(movie);
            }
            else
            {
                var movieDB = _moviecontext.Movies.Single(m => m.Id == movie.Id);
                movieDB.Name = movie.Name;
                movieDB.ReleaseDate = movie.ReleaseDate;
                movieDB.genreid = movie.genreid;
            }
            _moviecontext.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        public ActionResult Index()
        {
            var movie = _moviecontext.Movies.Include(mov => mov.genre);
            if (User.IsInRole(Storemanager.ManageMovies))
            {
                return View();
            }
            else
            {
                return View("ReadOnly");
            }

        }
        public ActionResult DispMovie(int id)
        {
            var movie = _moviecontext.Movies.Include(mov => mov.genre).SingleOrDefault(mov => mov.Id == id);
            if (movie == null)
                return HttpNotFound();
            var moviemodel = new MovieViewModel
            {
                genre = _moviecontext.Genre.ToList(),
                Movie = movie
            };
            ViewBag.Id = id;
            if(User.IsInRole(Storemanager.ManageMovies))
                return View("MovieForm", moviemodel);
            return View("DispMovie");
        }
 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using moviewatch.Models;
using moviewatch.App_Start;
using moviewatch.DTO;
using AutoMapper;
using System.Data.Entity;

namespace moviewatch.Controllers.api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/Movie
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include(m => m.genre ).ToList().Select(Mapper.Map<Movie,MovieDTO>));
        }

        // GET api/Movie/<id>
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Include(m => m.genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            else
            {
                return Ok(Mapper.Map<Movie, MovieDTO>(movie));
            }
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
                _context.Movies.Add(movie);
                _context.SaveChanges();

                movieDTO.Id = movie.Id;
                return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MovieDTO movieDTO)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            else
            {
                Mapper.Map(movieDTO, movie);
                _context.SaveChanges();
                return Ok(movieDTO);
            }
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
        
    }
}
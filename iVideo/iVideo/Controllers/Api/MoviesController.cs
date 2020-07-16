using AutoMapper;
using iVideo.Dtos;
using iVideo.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
namespace iVideo.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            var movieDto= Mapper.Map<Movie, MovieDto>(movie);

            return Ok(movieDto);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            movieDto.Id = movieInDb.Id;
            return Ok(movieDto);
        }

        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

using AutoMapper;
using iVideo.Dtos;
using iVideo.Models;
using System.Data.Entity;
using System;
using System.Linq;
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

        [HttpGet]
        public IHttpActionResult GetMovies(string query=null)
        {
            var moviesQuery = _context.Movies.Include(m => m.Genre);
            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query)).
                    Where(m => m.NumberAvailable > 0); 

            var movieDtos=moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);
        }

        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            var movieDto= Mapper.Map<Movie, MovieDto>(movie);

            return Ok(movieDto);
        }

        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        [HttpPost]
        public IHttpActionResult UpdateMovie(int id,[FromBody]MovieDto movieDto)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                var movie = Mapper.Map<MovieDto, Movie>(movieDto);
                _context.Movies.Add(movie);
                movieDto.Id = movie.Id;
            }
            else
            {
                Mapper.Map(movieDto, movieInDb);
                movieDto.Id = movieInDb.Id;
            }

            _context.SaveChanges();

            
            return Ok(movieDto);
        }

        
        [HttpDelete]
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

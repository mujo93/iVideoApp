using iVideo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iVideo.Controllers.Api
{
    public class RentalsController : ApiController
    {

        private ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //  Post api/customers/ReturnMovie/1
        [HttpPut]
        public IHttpActionResult CheckInMovie(int id)
        {
            var rental = _context.Rentals.Include(r=>r.Movie).SingleOrDefault(r => r.Id == id);
            var movieInRental = _context.Movies.SingleOrDefault(m => m.Id == rental.Movie.Id);

            if (rental == null)
                return NotFound();
            rental.DateReturned = DateTime.Now;
            movieInRental.NumberAvailable++;
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetRentedMovies()
        {
            var rentedMovies = _context.Rentals.
                Include(m=>m.Movie).
                Include(m=>m.Customer).
                Where(m=>m.DateReturned==null).
                ToList();

            return Ok(rentedMovies);
        }

        [HttpGet]
        public IHttpActionResult GetRentedMovies(int id)
        {
            var rentedMovies = _context.Rentals.
                Include(m => m.Movie).
                Include(m => m.Customer).
                Where(m=>m.Customer.Id==id).
                Where(m => m.DateReturned == null).
                ToList();

            return Ok(rentedMovies);
        }
    }
}

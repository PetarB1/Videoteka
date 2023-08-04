using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videoteka.DTOs;
using Videoteka.Models;

namespace Videoteka.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto newRental)
        {
            var customer = _context.Kupci.Single(
                c => c.Id == newRental.KupacId);

            var movies = _context.Films.Where(
                m => newRental.FilmIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.BrojDostupnih == 0)
                    return BadRequest("Movie is not available.");

                movie.BrojDostupnih--;

                var rental = new Rental
                {
                    Kupac = customer,
                    Film = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}

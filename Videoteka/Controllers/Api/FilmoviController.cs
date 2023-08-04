using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videoteka.DTOs;
using Videoteka.Models;
using System.Data.Entity;

namespace Videoteka.Controllers.Api
{
    public class FilmoviController : ApiController
    {
        private ApplicationDbContext _context;

        public FilmoviController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<FilmDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Films
                .Include(m => m.Zanr)
                .Where(m => m.BrojDostupnih > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Ime.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Film, FilmDto>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Films.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Film, FilmDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(FilmDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<FilmDto, Film>(movieDto);
            _context.Films.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, FilmDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Films.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Films.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Films.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
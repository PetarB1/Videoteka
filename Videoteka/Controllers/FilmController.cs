using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoteka.Models;
using Videoteka.ViewModels;

namespace Videoteka.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        private ApplicationDbContext _context;

        public FilmController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult List()
        {
            var filmovi= _context.Films.Include(m => m.Zanr).ToList();

            return View(filmovi);
        }

        public ActionResult New()
        {
            var zanr = _context.Zanrs.ToList();
            var viewModel = new FilmViewModel
            {
                Zanrs = zanr
            };

            return View("FilmForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Film film)
        {
           
            if (film.Id == 0)
            {
                _context.Films.Add(film);
            }
            else
            {
                var filmInDb = _context.Films.Single(c => c.Id == film.Id);

                filmInDb.Ime = film.Ime;
                filmInDb.ZanrId = film.ZanrId;
                filmInDb.DatumUnosa = film.DatumUnosa;
                filmInDb.DatumIzdanja = film.DatumIzdanja;
                filmInDb.BrojNaStanju = film.BrojNaStanju;
                filmInDb.BrojDostupnih = film.BrojDostupnih;
            }
            _context.SaveChanges();

            return RedirectToAction("List", "Film");
        }
        public ActionResult Edit(int id)
        {
            var film = _context.Films.SingleOrDefault(c => c.Id == id);

            if (film == null) return HttpNotFound();

            var viewModel = new FilmViewModel
            {
                Film = film,
                Zanrs = _context.Zanrs.ToList()
            };
            return View("FilmForm", viewModel);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var filmInDb = _context.Films.SingleOrDefault(c => c.Id == id);

            if (filmInDb == null)
            {
                return HttpNotFound();
            }

            _context.Films.Remove(filmInDb);
            _context.SaveChanges();

            return RedirectToAction("List", "Film");
        }
    }
}
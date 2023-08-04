using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoteka.Models;
using System.Data.Entity;
using Videoteka.ViewModels;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Data.Entity.Core.Metadata.Edm;

namespace Videoteka.Controllers
{
    public class KupacController : Controller
    {
        // GET: Kupac

        private ApplicationDbContext _context;
        public KupacController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult List()
        {
            var kupci = _context.Kupci.Include(k => k.TipClanstva).Include(k => k.TipKupca).ToList();

            return View(kupci);
        }
        public ActionResult New()
        {
            var tipClanstva = _context.TipClanstvas.ToList();
            var tipKupca = _context.TipKupcas.ToList();
            var viewModel = new KupacViewModel
            {
                TipClanstvas = tipClanstva,
                TipKupcas = tipKupca
            };

            return View("KupacForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Kupac kupac)
        {

            if (kupac.Id == 0)
            {
                _context.Kupci.Add(kupac);
            }
            else
            {
                var kupacInDb = _context.Kupci.Single(c => c.Id == kupac.Id);

                kupacInDb.Ime = kupac.Ime;
                kupacInDb.PrimaObavjestenja = kupac.PrimaObavjestenja;
                kupacInDb.DatumRodjenja = kupac.DatumRodjenja;
                kupacInDb.TipClanstvaId = kupac.TipClanstvaId;
                kupacInDb.TipKupcaId = kupac.TipKupcaId;
            }
            _context.SaveChanges();

            return RedirectToAction("List","Kupac");
        }
        public ActionResult Edit(int? id)
        {
            var customer = _context.Kupci.SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            var viewModel = new KupacViewModel
            {
                Kupac = customer,
                TipClanstvas = _context.TipClanstvas.ToList(),
                TipKupcas = _context.TipKupcas.ToList()
            };
            return View("KupacForm", viewModel);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var kupacInDb = _context.Kupci.SingleOrDefault(c => c.Id == id);

            if (kupacInDb == null)
            {
                return HttpNotFound();
            }

            _context.Kupci.Remove(kupacInDb);
            _context.SaveChanges();

            return RedirectToAction("List", "Kupac");
        }
    }
}
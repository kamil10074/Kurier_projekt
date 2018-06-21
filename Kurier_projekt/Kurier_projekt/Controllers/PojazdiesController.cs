using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kurier_projekt.Models;

namespace Kurier_projekt.Controllers
{
    public class PojazdiesController : Controller
    {
        private IndywidualniEntities db = new IndywidualniEntities();

        // GET: Pojazdies
        public ActionResult Index()
        {
            return View(db.Pojazdy.ToList());
        }

        // GET: Pojazdies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pojazdy pojazdy = db.Pojazdy.Find(id);
            if (pojazdy == null)
            {
                return HttpNotFound();
            }
            return View(pojazdy);
        }

        // GET: Pojazdies/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_pojazdu,Marka,Model,Rok_produkcji,Numer_rejestracyjny")] Pojazdy pojazdy)
        {
            if (ModelState.IsValid)
            {
                db.Pojazdy.Add(pojazdy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pojazdy);
        }


        // GET: Pojazdies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pojazdy pojazdy = db.Pojazdy.Find(id);
            if (pojazdy == null)
            {
                return HttpNotFound();
            }
            return View(pojazdy);
        }

        // POST: Pojazdies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pojazdy pojazdy = db.Pojazdy.Find(id);
            db.Pojazdy.Remove(pojazdy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

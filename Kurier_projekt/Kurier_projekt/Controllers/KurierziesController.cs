using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kurier_projekt.Models;
using PagedList;

namespace Kurier_projekt.Controllers
{
    public class KurierziesController : Controller
    {
        private IndywidualniEntities db = new IndywidualniEntities();

        // GET: Kurierzies
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var kuriers = from s in db.Kurierzy select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                kuriers = kuriers.Where(s => s.Imie.Contains(searchString) ||
                s.Nazwisko.Contains(searchString));
            }
            switch (sortOrder)
            {default:
                    kuriers = kuriers.OrderBy(s => s.Imie);
                    break;
            }

            int pageSize = 10;
            int pageNumer = (page ?? 1);
            return View(kuriers.ToPagedList(pageNumer, pageSize));
        }

        // GET: Kurierzies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurierzy kurierzy = db.Kurierzy.Find(id);
            if (kurierzy == null)
            {
                return HttpNotFound();
            }
            return View(kurierzy);
        }

        // GET: Kurierzies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kurierzies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Kurier,Imie,Nazwisko,Data_urodzenia,Data_zatrudnienia,Adres_kurier,Id_Pojazdu,Numer_telefonu")] Kurierzy kurierzy)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Kurierzy.Add(kurierzy);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Nie mozna dodac pracownika. Sprawdz poprawnosc wpisanych danych " +
                    "lub upewnij sie ze pojazd ktory przypisujesz do kuriera istnienieje w bazie danych");
            }


            return View(kurierzy);
        }

        // GET: Kurierzies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurierzy kurierzy = db.Kurierzy.Find(id);
            if (kurierzy == null)
            {
                return HttpNotFound();
            }
            return View(kurierzy);
        }

        // POST: Kurierzies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Kurier,Imie,Nazwisko,Data_urodzenia,Data_zatrudnienia,Adres_kurier,Id_Pojazdu,Numer_telefonu")] Kurierzy kurierzy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kurierzy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kurierzy);
        }

        // GET: Kurierzies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurierzy kurierzy = db.Kurierzy.Find(id);
            if (kurierzy == null)
            {
                return HttpNotFound();
            }
            return View(kurierzy);
        }

        // POST: Kurierzies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kurierzy kurierzy = db.Kurierzy.Find(id);
            db.Kurierzy.Remove(kurierzy);
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

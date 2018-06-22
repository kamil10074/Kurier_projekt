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
    public class PrzesyłkiController : Controller
    {
        private IndywidualniEntities db = new IndywidualniEntities();

        // GET: Przesyłki
        public ActionResult Index()
        {
            return View(db.Przesyłki.ToList());
        }

        // GET: Przesyłki/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przesyłki przesyłki = db.Przesyłki.Find(id);
            if (przesyłki == null)
            {
                return HttpNotFound();
            }
            return View(przesyłki);
        }

        // GET: Przesyłki/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Przesyłki/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Przesylki,Nadawca,Odbiorca,Data_nadania,Adres_nadawcy,Adres_odbiorcy,Id_Kurier")] Przesyłki przesyłki)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Przesyłki.Add(przesyłki);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Nie mozna dodac przesylki. Sprawdz poprawnosc wpisanych danych, poniewaz kurier nie istnieje");
            }

            return View(przesyłki);
        }


        // POST: Przesyłki/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Przesylki,Nadawca,Odbiorca,Data_nadania,Adres_nadawcy,Adres_odbiorcy,Id_Kurier")] Przesyłki przesyłki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(przesyłki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(przesyłki);
        }

        // GET: Przesyłki/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przesyłki przesyłki = db.Przesyłki.Find(id);
            if (przesyłki == null)
            {
                return HttpNotFound();
            }
            return View(przesyłki);
        }

        // POST: Przesyłki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Przesyłki przesyłki = db.Przesyłki.Find(id);
            db.Przesyłki.Remove(przesyłki);
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

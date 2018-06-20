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
    public class KurierziesController : Controller
    {
        private IndywidualniEntities db = new IndywidualniEntities();

        // GET: Kurierzies
        public ActionResult Index()
        {
            return View(db.Kurierzy.ToList());
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
            if (ModelState.IsValid)
            {
                db.Kurierzy.Add(kurierzy);
                db.SaveChanges();
                return RedirectToAction("Index");
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

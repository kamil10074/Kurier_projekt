using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kurier_projekt.DAL1;
using Kurier_projekt.Models;

namespace Kurier_projekt.Controllers
{
    public class AddKurierController : Controller
    {
        private KurierProjektContext db = new KurierProjektContext();
        // GET: AddKurier
    

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Dodajkuriera.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurierzy Dodajkuriera = db.Dodajkuriera.Find(id);
            if (Dodajkuriera == null)
            {
                return HttpNotFound();
            }
            return View(Dodajkuriera);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_kurier,Imie,Nazwisko,Data_urodzenia,Data_zatrudnienia,Adres_kurier,Id_Pojazdu,Numer_telefonu")] Kurierzy kurierzy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Dodajkuriera.Add(kurierzy);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the" + "problem persist see your system administrator.");
            }
            return View(kurierzy);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kurier_projekt.DAL;
using Kurier_projekt.Models;

namespace Kurier_projekt.Controllers
{
    public class KurierController : Controller
    {
        private KurierContext db = new KurierContext();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Kurierzy.ToList());
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
        public ActionResult Create([Bind(Include = "Id_Kuriera,Imie,Nazwisko")] Kurierzy student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Kurierzy.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the" + "problem persist see your system administrator.");
            }
            return View(student);
        }

    }
}
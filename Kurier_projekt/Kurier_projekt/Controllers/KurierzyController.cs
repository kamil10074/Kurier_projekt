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
using PagedList;

namespace UITMUniversity.Controllers
{
    public class KurierzyController : Controller
    {
        private KurierProjektContext db = new KurierProjektContext();

        // GET: Student
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
           ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var kurierzy = from s in db.Dodajkuriera select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                kurierzy = kurierzy.Where(s => s.Imie.Contains(searchString) ||
                s.Nazwisko.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    kurierzy = kurierzy.OrderByDescending(s => s.Imie);
                    break;
                case "Date":
                    kurierzy = kurierzy.OrderBy(s => s.Data_urodzenia);
                    break;
                case "date_desc":
                    kurierzy = kurierzy.OrderByDescending(s => s.Data_urodzenia);
                    break;
                default:
                    kurierzy = kurierzy.OrderBy(s => s.Nazwisko);
                    break;
            }
            int pageSize = 3;
            int pageNumer = (page ?? 1);
            return View(kurierzy.ToPagedList(pageNumer, pageSize));
        }


        // GET: Kurierzy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kurierzy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Imie,Nazwisko")] Kurierzy kurierzy)
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
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the " +
                    "problem persists see your system administrator.");
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

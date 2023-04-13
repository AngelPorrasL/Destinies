using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Destinies.Models;

namespace Destinies.Controllers
{
    public class HomeController : Controller
    {
        private TourEntities db = new TourEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Destinies.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destiny destiny = db.Destinies.Find(id);
            if (destiny == null)
            {
                return HttpNotFound();
            }
            return View(destiny);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,photo,price")] Destiny destiny)
        {
            if (ModelState.IsValid)
            {
                db.Destinies.Add(destiny);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destiny);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destiny destiny = db.Destinies.Find(id);
            if (destiny == null)
            {
                return HttpNotFound();
            }
            return View(destiny);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,photo,price")] Destiny destiny)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destiny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destiny);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destiny destiny = db.Destinies.Find(id);
            if (destiny == null)
            {
                return HttpNotFound();
            }
            return View(destiny);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destiny destiny = db.Destinies.Find(id);
            db.Destinies.Remove(destiny);
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

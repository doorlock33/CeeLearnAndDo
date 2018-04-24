using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CeeLearnAndDo.Models;

namespace CeeLearnAndDo.Controllers
{
    public class AdminReferenceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminReference
        [Authorize]
        public ActionResult Index()
        {
            return View(db.References.ToList());
        }

        // GET: AdminReference/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference reference = db.References.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // GET: AdminReference/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminReference/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Image")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                reference.Date = DateTime.Now;
                db.References.Add(reference);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reference);
        }

        // GET: AdminReference/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference reference = db.References.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // POST: AdminReference/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,Image")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                reference.Date = DateTime.Now;
                db.Entry(reference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reference);
        }

        // GET: AdminReference/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference reference = db.References.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // POST: AdminReference/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reference reference = db.References.Find(id);
            db.References.Remove(reference);
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

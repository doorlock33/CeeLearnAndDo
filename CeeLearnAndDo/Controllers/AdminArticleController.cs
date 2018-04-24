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
using Microsoft.AspNet.Identity;

namespace CeeLearnAndDo.Controllers
{
    public class AdminArticleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminArticle
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        // GET: AdminArticle/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: AdminArticle/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminArticle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Picture")] Article article, HttpPostedFileBase Picture)
        {
            if (ModelState.IsValid)
            {
                // generate random guid string as fileName
                Guid g = Guid.NewGuid();
                string fileName = Convert.ToBase64String(g.ToByteArray());
                fileName = fileName.Replace("=", "");
                fileName = fileName.Replace("+", "");
                fileName = fileName.Replace("/", "");
                fileName = fileName + "-article" + Path.GetExtension(Picture.FileName);

                // save image
                string path = Path.Combine(Server.MapPath("~/UploadedFiles/ArticleImages"), fileName);
                Picture.SaveAs(path);
                article.Picture = fileName;

                article.Date = DateTime.Now;
                article.UserId = User.Identity.GetUserId();
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: AdminArticle/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: AdminArticle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,Picture")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.Date = DateTime.Now;
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: AdminArticle/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: AdminArticle/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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

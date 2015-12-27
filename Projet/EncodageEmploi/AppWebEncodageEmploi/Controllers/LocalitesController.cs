using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppWebEncodageEmploi;

namespace AppWebEncodageEmploi.Controllers
{
    public class LocalitesController : Controller
    {
        private DBIG3B1Entities db = new DBIG3B1Entities();

        // GET: Localites
        public ActionResult Index()
        {
            return View(db.Localites.ToList());
        }

        // GET: Localites/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localite localite = db.Localites.Find(id);
            if (localite == null)
            {
                return HttpNotFound();
            }
            return View(localite);
        }

        // GET: Localites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Localites/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,CodePostal,Pays")] Localite localite)
        {
            if (ModelState.IsValid)
            {
                db.Localites.Add(localite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localite);
        }

        // GET: Localites/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localite localite = db.Localites.Find(id);
            if (localite == null)
            {
                return HttpNotFound();
            }
            return View(localite);
        }

        // POST: Localites/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,CodePostal,Pays")] Localite localite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localite);
        }

        // GET: Localites/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localite localite = db.Localites.Find(id);
            if (localite == null)
            {
                return HttpNotFound();
            }
            return View(localite);
        }

        // POST: Localites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Localite localite = db.Localites.Find(id);
            db.Localites.Remove(localite);
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

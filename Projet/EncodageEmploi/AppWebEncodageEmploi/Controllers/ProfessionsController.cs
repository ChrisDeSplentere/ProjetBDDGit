﻿using System;
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
    public class ProfessionsController : Controller
    {
        private DBIG3B1Entities db = new DBIG3B1Entities();

        // GET: Professions
        public ActionResult Index()
        {
            return View(db.Professions.ToList());
        }

        // GET: Professions/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // GET: Professions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Denomination")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Professions.Add(profession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profession);
        }

        // GET: Professions/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // POST: Professions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Denomination")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profession);
        }

        // GET: Professions/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // POST: Professions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Profession profession = db.Professions.Find(id);
            db.Professions.Remove(profession);
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

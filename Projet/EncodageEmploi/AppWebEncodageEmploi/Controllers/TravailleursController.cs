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
    public class TravailleursController : Controller
    {
        private DBIG3B1Entities db = new DBIG3B1Entities();

        // GET: Travailleurs
        public ActionResult Index()
        {
            var travailleurs = db.Travailleurs.Include(t => t.Localite);
            return View(travailleurs.ToList());
        }

        // GET: Travailleurs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travailleur travailleur = db.Travailleurs.Find(id);
            if (travailleur == null)
            {
                return HttpNotFound();
            }
            return View(travailleur);
        }

        // GET: Travailleurs/Create
        public ActionResult Create()
        {
            ViewBag.IDDomicile = new SelectList(db.Localites, "ID", "CodeNom");
            return View();
        }

        // POST: Travailleurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Prenom,Sexe,NomRueDomicile,NumeroRueDomicile,NumDossierMedic,IDDomicile")] Travailleur travailleur)
        {
            if (ModelState.IsValid)
            {
                db.Travailleurs.Add(travailleur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDomicile = new SelectList(db.Localites, "ID", "CodeNom", travailleur.IDDomicile);
            return View(travailleur);
        }

        // GET: Travailleurs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travailleur travailleur = db.Travailleurs.Find(id);
            if (travailleur == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDomicile = new SelectList(db.Localites, "ID", "Nom", travailleur.IDDomicile);
            return View(travailleur);
        }

        // POST: Travailleurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Prenom,Sexe,NomRueDomicile,NumeroRueDomicile,NumDossierMedic,IDDomicile")] Travailleur travailleur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travailleur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDomicile = new SelectList(db.Localites, "ID", "Nom", travailleur.IDDomicile);
            return View(travailleur);
        }

        // GET: Travailleurs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travailleur travailleur = db.Travailleurs.Find(id);
            if (travailleur == null)
            {
                return HttpNotFound();
            }
            return View(travailleur);
        }

        // POST: Travailleurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Travailleur travailleur = db.Travailleurs.Find(id);
            db.Travailleurs.Remove(travailleur);
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

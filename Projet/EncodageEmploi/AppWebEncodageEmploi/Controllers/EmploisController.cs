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
    public class EmploisController : Controller
    {
        private DBIG3B1Entities db = new DBIG3B1Entities();

        // GET: Emplois
        public ActionResult Index()
        {
            var emplois = db.Emplois.Include(e => e.Entreprise).Include(e => e.Profession).Include(e => e.Travailleur);
            return View(emplois.ToList());
        }

        // GET: Emplois/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emploi emploi = db.Emplois.Find(id);
            if (emploi == null)
            {
                return HttpNotFound();
            }
            return View(emploi);
        }

        // GET: Emplois/Create
        public ActionResult Create()
        {
            ViewBag.NumeroEntreprise = new SelectList(db.Entreprises, "Numero", "Denomination");
            ViewBag.CodeProfession = new SelectList(db.Professions, "Code", "Denomination");
            ViewBag.IDTravailleur = new SelectList(db.Travailleurs, "ID", "NomPrenomId");
            return View();
        }

        // POST: Emplois/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EstSoumis,DateDebut,IDTravailleur,CodeProfession,DateFin,NumeroEntreprise")] Emploi emploi)
        {
            if (ModelState.IsValid)
            {
                db.Emplois.Add(emploi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NumeroEntreprise = new SelectList(db.Entreprises, "Numero", "Denomination", emploi.NumeroEntreprise);
            ViewBag.CodeProfession = new SelectList(db.Professions, "Code", "Denomination", emploi.CodeProfession);
            ViewBag.IDTravailleur = new SelectList(db.Travailleurs, "ID", "NomPrenomId", emploi.IDTravailleur);
            return View(emploi);
        }

        // GET: Emplois/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emploi emploi = db.Emplois.Find(id);
            if (emploi == null)
            {
                return HttpNotFound();
            }
            ViewBag.NumeroEntreprise = new SelectList(db.Entreprises, "Numero", "Denomination", emploi.NumeroEntreprise);
            ViewBag.CodeProfession = new SelectList(db.Professions, "Code", "Denomination", emploi.CodeProfession);
            ViewBag.IDTravailleur = new SelectList(db.Travailleurs, "ID", "Nom", emploi.IDTravailleur);
            return View(emploi);
        }

        // POST: Emplois/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EstSoumis,DateDebut,IDTravailleur,CodeProfession,DateFin,NumeroEntreprise")] Emploi emploi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emploi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NumeroEntreprise = new SelectList(db.Entreprises, "Numero", "Denomination", emploi.NumeroEntreprise);
            ViewBag.CodeProfession = new SelectList(db.Professions, "Code", "Denomination", emploi.CodeProfession);
            ViewBag.IDTravailleur = new SelectList(db.Travailleurs, "ID", "Nom", emploi.IDTravailleur);
            return View(emploi);
        }

        // GET: Emplois/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emploi emploi = db.Emplois.Find(id);
            if (emploi == null)
            {
                return HttpNotFound();
            }
            return View(emploi);
        }

        // POST: Emplois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Emploi emploi = db.Emplois.Find(id);
            db.Emplois.Remove(emploi);
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

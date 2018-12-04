using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final.Models;

namespace Final.Controllers
{
    public class RecaudadoesController : Controller
    {
        private BDFinalEntities db = new BDFinalEntities();

        // GET: Recaudadoes
        public ActionResult Index()
        {
            var recaudado = db.Recaudado.Include(r => r.Doctor);
            return View(recaudado.ToList());
        }

        // GET: Recaudadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recaudado recaudado = db.Recaudado.Find(id);
            if (recaudado == null)
            {
                return HttpNotFound();
            }
            return View(recaudado);
        }

        // GET: Recaudadoes/Create
        public ActionResult Create()
        {
            ViewBag.id_doctor = new SelectList(db.Doctor, "id", "cedula");
            return View();
        }

        // POST: Recaudadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_doctor,recaudado1")] Recaudado recaudado)
        {
            if (ModelState.IsValid)
            {
                db.Recaudado.Add(recaudado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_doctor = new SelectList(db.Doctor, "id", "cedula", recaudado.id_doctor);
            return View(recaudado);
        }

        // GET: Recaudadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recaudado recaudado = db.Recaudado.Find(id);
            if (recaudado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_doctor = new SelectList(db.Doctor, "id", "cedula", recaudado.id_doctor);
            return View(recaudado);
        }

        // POST: Recaudadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_doctor,recaudado1")] Recaudado recaudado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recaudado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_doctor = new SelectList(db.Doctor, "id", "cedula", recaudado.id_doctor);
            return View(recaudado);
        }

        // GET: Recaudadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recaudado recaudado = db.Recaudado.Find(id);
            if (recaudado == null)
            {
                return HttpNotFound();
            }
            return View(recaudado);
        }

        // POST: Recaudadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recaudado recaudado = db.Recaudado.Find(id);
            db.Recaudado.Remove(recaudado);
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

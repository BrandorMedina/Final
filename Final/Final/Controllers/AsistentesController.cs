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
    public class AsistentesController : Controller
    {
        private BDFinalEntities db = new BDFinalEntities();

        // GET: Asistentes
        public ActionResult Index()
        {
            return View(db.Asistentes.ToList());
        }

        // GET: Asistentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistentes asistentes = db.Asistentes.Find(id);
            if (asistentes == null)
            {
                return HttpNotFound();
            }
            return View(asistentes);
        }

        // GET: Asistentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asistentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cedula,nombre,apellido,telefono,usuario,clave")] Asistentes asistentes)
        {
            if (ModelState.IsValid)
            {
                db.Asistentes.Add(asistentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asistentes);
        }

        // GET: Asistentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistentes asistentes = db.Asistentes.Find(id);
            if (asistentes == null)
            {
                return HttpNotFound();
            }
            return View(asistentes);
        }

        // POST: Asistentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cedula,nombre,apellido,telefono,usuario,clave")] Asistentes asistentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asistentes);
        }

        // GET: Asistentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistentes asistentes = db.Asistentes.Find(id);
            if (asistentes == null)
            {
                return HttpNotFound();
            }
            return View(asistentes);
        }

        // POST: Asistentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistentes asistentes = db.Asistentes.Find(id);
            db.Asistentes.Remove(asistentes);
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

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
    public class RecetasController : Controller
    {
        private BDFinalEntities db = new BDFinalEntities();

        // GET: Recetas
        public ActionResult Index()
        {
            var recetas = db.Recetas.Include(r => r.Doctor).Include(r => r.Pacientes);
            return View(recetas.ToList());
        }

        // GET: Recetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recetas recetas = db.Recetas.Find(id);
            if (recetas == null)
            {
                return HttpNotFound();
            }
            return View(recetas);
        }

        // GET: Recetas/Create
        public ActionResult Create()
        {
            ViewBag.id_doctor = new SelectList(db.Doctor, "id", "cedula");
            ViewBag.id_paciente = new SelectList(db.Pacientes, "id", "cedula");
            return View();
        }

        // POST: Recetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_paciente,id_doctor,fecha,medicamentos,descripcion")] Recetas recetas)
        {
            if (ModelState.IsValid)
            {
                db.Recetas.Add(recetas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_doctor = new SelectList(db.Doctor, "id", "cedula", recetas.id_doctor);
            ViewBag.id_paciente = new SelectList(db.Pacientes, "id", "cedula", recetas.id_paciente);
            return View(recetas);
        }

        // GET: Recetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recetas recetas = db.Recetas.Find(id);
            if (recetas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_doctor = new SelectList(db.Doctor, "id", "cedula", recetas.id_doctor);
            ViewBag.id_paciente = new SelectList(db.Pacientes, "id", "cedula", recetas.id_paciente);
            return View(recetas);
        }

        // POST: Recetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_paciente,id_doctor,fecha,medicamentos,descripcion")] Recetas recetas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recetas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_doctor = new SelectList(db.Doctor, "id", "cedula", recetas.id_doctor);
            ViewBag.id_paciente = new SelectList(db.Pacientes, "id", "cedula", recetas.id_paciente);
            return View(recetas);
        }

        // GET: Recetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recetas recetas = db.Recetas.Find(id);
            if (recetas == null)
            {
                return HttpNotFound();
            }
            return View(recetas);
        }

        // POST: Recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recetas recetas = db.Recetas.Find(id);
            db.Recetas.Remove(recetas);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Organizate;

namespace Organizate.Controllers
{
    public class AsistenciasController : Controller
    {
        private DB_A44489_asistenciaEntities db = new DB_A44489_asistenciaEntities();

        // GET: Asistencias
        public ActionResult Index()
        {
            var asistencia = db.Asistencia.Include(a => a.Estudiante).Include(a => a.Tema);
            return View(asistencia.ToList());
        }

        // GET: Asistencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: Asistencias/Create
        public ActionResult Create()
        {
            ViewBag.asi_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre");
            ViewBag.asi_tema_id = new SelectList(db.Tema, "tema_id", "tema_nombre");
            return View();
        }

        // POST: Asistencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "asi_id,asi_fecha,asi_hora_inicio,asi_hora_fin,asi_tiempo,asi_contenido,asi_est_id,asi_tema_id")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Asistencia.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.asi_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre", asistencia.asi_est_id);
            ViewBag.asi_tema_id = new SelectList(db.Tema, "tema_id", "tema_nombre", asistencia.asi_tema_id);
            return View(asistencia);
        }

        // GET: Asistencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.asi_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre", asistencia.asi_est_id);
            ViewBag.asi_tema_id = new SelectList(db.Tema, "tema_id", "tema_nombre", asistencia.asi_tema_id);
            return View(asistencia);
        }

        // POST: Asistencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "asi_id,asi_fecha,asi_hora_inicio,asi_hora_fin,asi_tiempo,asi_contenido,asi_est_id,asi_tema_id")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.asi_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre", asistencia.asi_est_id);
            ViewBag.asi_tema_id = new SelectList(db.Tema, "tema_id", "tema_nombre", asistencia.asi_tema_id);
            return View(asistencia);
        }

        // GET: Asistencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistencia asistencia = db.Asistencia.Find(id);
            db.Asistencia.Remove(asistencia);
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

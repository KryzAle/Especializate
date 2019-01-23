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
    public class EstudiantesController : Controller
    {
        private DB_A44489_asistenciaEntities db = new DB_A44489_asistenciaEntities();

        // GET: Estudiantes
        public ActionResult Index()
        {
            return View(db.Estudiante.ToList());
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Estudiante estudiante = db.Estudiante.Find(id);
                if (estudiante == null)
                {
                    return HttpNotFound();
                }
                return View(estudiante);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Estudiantes/Index" });
            
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Estudiantes/Create" });
            
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "est_id,est_nombre,est_apellido,est_telefono,est_direccion,est_correo,est_cedula,est_cole_univ")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Estudiante.Add(estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Estudiante estudiante = db.Estudiante.Find(id);
                if (estudiante == null)
                {
                    return HttpNotFound();
                }
                return View(estudiante);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Estudiantes/Index" });

            
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "est_id,est_nombre,est_apellido,est_telefono,est_direccion,est_correo,est_cedula,est_cole_univ")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Estudiante estudiante = db.Estudiante.Find(id);
                if (estudiante == null)
                {
                    return HttpNotFound();
                }
                return View(estudiante);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Estudiantes/Index" });
            
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            db.Estudiante.Remove(estudiante);
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

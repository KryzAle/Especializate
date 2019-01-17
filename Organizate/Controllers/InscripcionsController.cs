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
    public class InscripcionsController : Controller
    {
        private DB_A44489_asistenciaEntities db = new DB_A44489_asistenciaEntities();

        // GET: Inscripcions
        
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var inscripcion = db.Inscripcion.Include(i => i.Estudiante);
                return View(inscripcion.ToList());
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Inscripcions/Index" });
            
        }

        // GET: Inscripcions/Details/5
        public ActionResult Details(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Inscripcion inscripcion = db.Inscripcion.Find(id);
                if (inscripcion == null)
                {
                    return HttpNotFound();
                }
                return View(inscripcion);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Inscripcions/Index" });


           
        }

        // GET: Inscripcions/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.ins_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre");
                return View();
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Inscripcions/Create" });

            
        }

        // POST: Inscripcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ins_id,ins_fecha,ins_valor,ins_total_horas,ins_est_id")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                inscripcion.ins_valor = 10 * inscripcion.ins_total_horas;
                db.Inscripcion.Add(inscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ins_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre", inscripcion.ins_est_id);
            return View(inscripcion);
        }

        // GET: Inscripcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Inscripcion inscripcion = db.Inscripcion.Find(id);
                if (inscripcion == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ins_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre", inscripcion.ins_est_id);
                return View(inscripcion);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Inscripcions/Edit" });
            
        }

        // POST: Inscripcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ins_id,ins_fecha,ins_valor,ins_total_horas,ins_est_id")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ins_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre", inscripcion.ins_est_id);
            return View(inscripcion);
        }

        // GET: Inscripcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Inscripcion inscripcion = db.Inscripcion.Find(id);
                if (inscripcion == null)
                {
                    return HttpNotFound();
                }
                return View(inscripcion);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Inscripcions/Delete" });

            
        }

        // POST: Inscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            db.Inscripcion.Remove(inscripcion);
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

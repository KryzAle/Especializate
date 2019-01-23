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
    public class MateriasController : Controller
    {
        private DB_A44489_asistenciaEntities db = new DB_A44489_asistenciaEntities();

        // GET: Materias
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View(db.Materia.ToList());
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Materias/Index" });
            
        }

        // GET: Materias/Details/5
        public ActionResult Details(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Materia materia = db.Materia.Find(id);
                if (materia == null)
                {
                    return HttpNotFound();
                }
                return View(materia);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Materias/Index" });
            
        }

        // GET: Materias/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Materias/Create" });
        }

        // POST: Materias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mat_id,mat_nombre")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Materia.Add(materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materia);
        }

        // GET: Materias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Materia materia = db.Materia.Find(id);
                if (materia == null)
                {
                    return HttpNotFound();
                }
                return View(materia);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Materias/Index" });
            
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mat_id,mat_nombre")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materia);
        }

        // GET: Materias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Materia materia = db.Materia.Find(id);
                if (materia == null)
                {
                    return HttpNotFound();
                }
                return View(materia);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Materias/Index" });
            
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Materia materia = db.Materia.Find(id);
            db.Materia.Remove(materia);
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

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
    public class TemasController : Controller
    {
        private DB_A44489_asistenciaEntities db = new DB_A44489_asistenciaEntities();

        // GET: Temas
        public ActionResult Index()
        {
            var tema = db.Tema.Include(t => t.Profesor_Materia);
            return View(tema.ToList());
        }

        // GET: Temas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // GET: Temas/Create
        public ActionResult Create()
        {
            ViewBag.tema_pro_mat_id = new SelectList(db.Profesor_Materia, "pro_mat_id", "pro_mat_id");
            return View();
        }

        // POST: Temas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tema_id,tema_nombre,tema_pro_mat_id")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                db.Tema.Add(tema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tema_pro_mat_id = new SelectList(db.Profesor_Materia, "pro_mat_id", "pro_mat_id", tema.tema_pro_mat_id);
            return View(tema);
        }

        // GET: Temas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            ViewBag.tema_pro_mat_id = new SelectList(db.Profesor_Materia, "pro_mat_id", "pro_mat_id", tema.tema_pro_mat_id);
            return View(tema);
        }

        // POST: Temas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tema_id,tema_nombre,tema_pro_mat_id")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tema_pro_mat_id = new SelectList(db.Profesor_Materia, "pro_mat_id", "pro_mat_id", tema.tema_pro_mat_id);
            return View(tema);
        }

        // GET: Temas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // POST: Temas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tema tema = db.Tema.Find(id);
            db.Tema.Remove(tema);
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

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
    public class Profesor_MateriaController : Controller
    {
        private DB_A44489_asistenciaEntities db = new DB_A44489_asistenciaEntities();

        // GET: Profesor_Materia
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var profesor_Materia = db.Profesor_Materia.Include(p => p.Materia).Include(p => p.Profesor);
                return View(profesor_Materia.ToList());
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Profesor_Materia/Index" });
            
        }

        // GET: Profesor_Materia/Details/5
        public ActionResult Details(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Profesor_Materia profesor_Materia = db.Profesor_Materia.Find(id);
                if (profesor_Materia == null)
                {
                    return HttpNotFound();
                }
                return View(profesor_Materia);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Profesor_Materia/Index" });
            
        }

        // GET: Profesor_Materia/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.pro_mat_mat_id = new SelectList(db.Materia, "mat_id", "mat_nombre");
                ViewBag.pro_mat_pro_id = new SelectList(db.Profesor, "pro_id", "nombreCompleto");
                return View();
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Profesor_Materia/Create" });
            
        }

        // POST: Profesor_Materia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profesor_Materia profesor_Materia)
        {
            if (ModelState.IsValid)
            {
                db.Profesor_Materia.Add(profesor_Materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pro_mat_mat_id = new SelectList(db.Materia, "mat_id", "mat_nombre", profesor_Materia.pro_mat_mat_id);
            ViewBag.pro_mat_pro_id = new SelectList(db.Profesor, "pro_id", "pro_nombre", profesor_Materia.pro_mat_pro_id);
            return View(profesor_Materia);
        }

        // GET: Profesor_Materia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Profesor_Materia profesor_Materia = db.Profesor_Materia.Find(id);
                if (profesor_Materia == null)
                {
                    return HttpNotFound();
                }
                ViewBag.pro_mat_mat_id = new SelectList(db.Materia, "mat_id", "mat_nombre", profesor_Materia.pro_mat_mat_id);
                ViewBag.pro_mat_pro_id = new SelectList(db.Profesor, "pro_id", "pro_nombre", profesor_Materia.pro_mat_pro_id);
                return View(profesor_Materia);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Profesor_Materia/Index" });
            
        }

        // POST: Profesor_Materia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pro_mat_id,pro_mat_pro_id,pro_mat_mat_id")] Profesor_Materia profesor_Materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesor_Materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pro_mat_mat_id = new SelectList(db.Materia, "mat_id", "mat_nombre", profesor_Materia.pro_mat_mat_id);
            ViewBag.pro_mat_pro_id = new SelectList(db.Profesor, "pro_id", "pro_nombre", profesor_Materia.pro_mat_pro_id);
            return View(profesor_Materia);
        }

        // GET: Profesor_Materia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Profesor_Materia profesor_Materia = db.Profesor_Materia.Find(id);
                if (profesor_Materia == null)
                {
                    return HttpNotFound();
                }
                return View(profesor_Materia);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Profesor_Materia/Index" });
            
        }

        // POST: Profesor_Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesor_Materia profesor_Materia = db.Profesor_Materia.Find(id);
            db.Profesor_Materia.Remove(profesor_Materia);
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

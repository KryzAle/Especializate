﻿using System;
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
    public class Horario_ProfesorController : Controller
    {
        private DB_A44489_asistenciaEntities db = new DB_A44489_asistenciaEntities();

        // GET: Horario_Profesor
        public ActionResult Index()
        {
            var horario_Profesor = db.Horario_Profesor.Include(h => h.Profesor);
            return View(horario_Profesor.ToList());
        }

        // GET: Horario_Profesor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario_Profesor horario_Profesor = db.Horario_Profesor.Find(id);
            if (horario_Profesor == null)
            {
                return HttpNotFound();
            }
            return View(horario_Profesor);
        }

        // GET: Horario_Profesor/Create
        public ActionResult Create()
        {
            ViewBag.hor_pro_pro_id = new SelectList(db.Profesor, "pro_id", "pro_nombre");
            return View();
        }

        // POST: Horario_Profesor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hor_pro_id,hor_pro_dia,hor_pro_hora_inicio,hor_pro_hora_fin,hor_pro_pro_id")] Horario_Profesor horario_Profesor)
        {
            if (ModelState.IsValid)
            {
                db.Horario_Profesor.Add(horario_Profesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hor_pro_pro_id = new SelectList(db.Profesor, "pro_id", "pro_nombre", horario_Profesor.hor_pro_pro_id);
            return View(horario_Profesor);
        }

        // GET: Horario_Profesor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario_Profesor horario_Profesor = db.Horario_Profesor.Find(id);
            if (horario_Profesor == null)
            {
                return HttpNotFound();
            }
            ViewBag.hor_pro_pro_id = new SelectList(db.Profesor, "pro_id", "pro_nombre", horario_Profesor.hor_pro_pro_id);
            return View(horario_Profesor);
        }

        // POST: Horario_Profesor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hor_pro_id,hor_pro_dia,hor_pro_hora_inicio,hor_pro_hora_fin,hor_pro_pro_id")] Horario_Profesor horario_Profesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario_Profesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hor_pro_pro_id = new SelectList(db.Profesor, "pro_id", "pro_nombre", horario_Profesor.hor_pro_pro_id);
            return View(horario_Profesor);
        }

        // GET: Horario_Profesor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario_Profesor horario_Profesor = db.Horario_Profesor.Find(id);
            if (horario_Profesor == null)
            {
                return HttpNotFound();
            }
            return View(horario_Profesor);
        }

        // POST: Horario_Profesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario_Profesor horario_Profesor = db.Horario_Profesor.Find(id);
            db.Horario_Profesor.Remove(horario_Profesor);
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

using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizate.Controllers
{
    public class ReportesController : Controller
    {
        private DB_A44489_asistenciaEntities db = new DB_A44489_asistenciaEntities();
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ReporteEstudiante(String cedula)
        {
            List<Tema> temas = new List<Tema>();
            Estudiante estudiante = db.Estudiante.Where(x => x.est_cedula == cedula).FirstOrDefault();
            if (estudiante!=null)
            {
                int idStudent = estudiante.est_id;
                List<Asistencia> asistencia = db.Asistencia.Where(x => x.asi_est_id == idStudent).ToList();
                ViewBag.asistencia = asistencia;
                ViewBag.inscripcion = estudiante.Inscripcion.Last();
                ViewBag.transcurrido = estudiante.Inscripcion.Last().ins_total_horas - estudiante.Inscripcion.Last().ins_saldo;
                return View(estudiante);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: Reportes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reportes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reportes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reportes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reportes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reportes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Export(String cedula)
        {
            return new ActionAsPdf("ReporteEstudiante", new { cedula })
            {
                FileName = Server.MapPath("~/Content/Reporter.pdf")
            };
        }
    }
}

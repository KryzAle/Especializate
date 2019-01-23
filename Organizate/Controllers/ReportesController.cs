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
            List<Tema> currentTema;
            List<Tema> temas = new List<Tema>();
            Estudiante estudiante = db.Estudiante.Where(x => x.est_cedula == cedula).FirstOrDefault();
            if (estudiante!=null)
            {
                int idStudent = estudiante.est_id;
                List<Asistencia> asistencia = db.Asistencia.Where(x => x.asi_est_id == idStudent).ToList();
                ViewBag.asistencia = asistencia;
                ViewBag.inscripcion = estudiante.Inscripcion.Last();

                foreach(var asistenciavalor in asistencia)
                {
                    currentTema = db.Tema.Where(x => x.tema_id == asistenciavalor.asi_tema_id).ToList();
                    temas.Add(new Tema {
                        tema_id = currentTema.Last().tema_id,
                        tema_nombre = currentTema.Last().tema_nombre,
                        tema_pro_mat_id = currentTema.Last().tema_pro_mat_id
                    });
                }                
                ViewBag.tema = temas;
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
    }
}

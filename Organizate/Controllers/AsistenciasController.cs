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
        public static Tema temaCita = new Tema();
        private DB_A44489_asistenciaEntities db = new DB_A44489_asistenciaEntities();

        // GET: Asistencias
        public ActionResult Cita()
        {
            if (Request.IsAuthenticated)
            {
                var asistencia = db.Asistencia.Include(a => a.Estudiante).Include(a => a.Tema);
                return View(asistencia.ToList());
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencia/Cita" });

        }
        public JsonResult TraerTemas(int id)
        {
            IList<Profesor_Materia> profesor_materia = db.Profesor_Materia.Where(t => t.pro_mat_mat_id == id ).ToList();
            var listaTemasMat = new List<Tema>();
            foreach (var itemProfesorMateria in profesor_materia)
            {
                foreach (var item in itemProfesorMateria.Tema)
                {
                    
                        listaTemasMat.Add(item);
                }
            }
           var data = new SelectList(listaTemasMat.ToList(), "tema_id", "tema_nombre");
            return Json(data, JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult CreateCita()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.pro_mat_mat_id = new SelectList(db.Materia, "mat_id", "mat_nombre");
                return View();
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencia/CreateCita" });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCita(int tema_id)
        {
            temaCita= db.Tema.Find(tema_id);
            

            return RedirectToAction("RegistrarCita");
        }
        public ActionResult RegistrarCita()
        {
            Profesor_Materia profesor_materia = db.Profesor_Materia.Find(temaCita.tema_pro_mat_id);
            List<Horario_Profesor> horario_profesor = db.Horario_Profesor.Where(x => x.hor_pro_pro_id == profesor_materia.pro_mat_pro_id).ToList();
            ViewBag.asi_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre");
            return View(horario_profesor.ToList());
        }
        public ActionResult ConfirmarCita(int id)
        {
            Horario_Profesor horario = db.Horario_Profesor.Find(id);
            Asistencia asistencia = new Asistencia();
            asistencia.asi_tema_id = temaCita.tema_id;
            asistencia.asi_hora_inicio = horario.hor_pro_hora_inicio;
            DateTime dt = DateTime.Now;
            var desicion = true;
            do
            {
                int dia =(int) dt.DayOfWeek;
                string dialetra = obtenerDia(dia);
                if (dialetra.Equals(horario.hor_pro_dia))
                {
                    asistencia.asi_fecha = dt;
                    desicion = false;
                }
                dt = dt.AddDays(1);
            } while (desicion);
            ViewBag.asi_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre");
            return View(asistencia);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarCita(Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Asistencia.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Cita");
            }

            ViewBag.asi_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre", asistencia.asi_est_id);
            return View(asistencia);
        }
        public string obtenerDia(int dia)
        {
            string dialetra = "";
            switch (dia)
            {
                
                case 1:
                    dialetra = "Lunes";
                    break;
                case 2:
                    dialetra = "Martes";
                    break;
                case 3:
                    dialetra = "Miercoles";
                    break;
                case 4:
                    dialetra = "Jueves";
                    break;
                case 5:
                    dialetra = "Viernes";
                    break;
                case 6:
                    dialetra = "Sabado";
                    break;
                case 7:
                    dialetra = "Domingo";
                    break;

            }
            return dialetra;
        }
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

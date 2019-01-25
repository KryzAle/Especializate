using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
                var asistencia = db.Asistencia.Where(x => x.asi_hora_fin==null);
                return View(asistencia.ToList());
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/Cita" });

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
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/CreateCita" });

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
            if (Request.IsAuthenticated)
            {
                Profesor_Materia profesor_materia = db.Profesor_Materia.Find(temaCita.tema_pro_mat_id);
                List<Horario_Profesor> horario_profesor = db.Horario_Profesor.Where(x => x.hor_pro_pro_id == profesor_materia.pro_mat_pro_id).ToList();
                ViewBag.asi_est_id = new SelectList(db.Estudiante, "est_id", "est_nombre");
                return View(horario_profesor.ToList());
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/Cita" });
           
        }
        public ActionResult ConfirmarCita(int id)
        {
            if (Request.IsAuthenticated)
            {
                Horario_Profesor horario = db.Horario_Profesor.Find(id);

                Asistencia asistencia = new Asistencia();
                asistencia.asi_tema_id = temaCita.tema_id;
                asistencia.asi_hora_inicio = horario.hor_pro_hora_inicio;
                DateTime dt = DateTime.Now;
                var desicion = true;
                do
                {
                    int dia = (int)dt.DayOfWeek;
                    string dialetra = obtenerDia(dia);
                    if (dialetra.Equals(horario.hor_pro_dia))
                    {
                        asistencia.asi_fecha = dt;
                        desicion = false;
                    }
                    dt = dt.AddDays(1);
                } while (desicion);
                List<Estudiante> estudiantesInscritos = buscarEstudiantesInscritos();
                ViewBag.asi_est_id = new SelectList(estudiantesInscritos.ToList(), "est_id", "nombreCompleto");
                return View(asistencia);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/Cita" });
           
        }
        public List<Estudiante> buscarEstudiantesInscritos()
        {
            List<Estudiante> estudiantes = db.Estudiante.ToList();
            List<Estudiante> estudiantesInscritos = new List<Estudiante>();
            foreach (var item in estudiantes)
            {
                List<Inscripcion> inscripciones = db.Inscripcion.Where(x => x.ins_est_id == item.est_id).ToList();
                if (inscripciones.Count != 0)
                {
                    Inscripcion inscripcion = inscripciones.Last();
                    if (inscripcion.ins_saldo > 0)
                    {
                        estudiantesInscritos.Add(item);
                    }
                }

            }
            return estudiantesInscritos.ToList();
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
            List<Estudiante> estudiantesInscritos = buscarEstudiantesInscritos();
            ViewBag.asi_est_id = new SelectList(estudiantesInscritos.ToList(), "est_id", "nombreCompleto", asistencia.asi_est_id);
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
            if (Request.IsAuthenticated)
            {
                string idUser = User.Identity.GetUserId();
                List<Tema> temas = new List<Tema>();
                List<Profesor_Materia> materiasprofesor = db.Profesor_Materia.Where(x => x.pro_mat_pro_id == idUser).ToList();
                foreach (var item in materiasprofesor)
                {
                    temas.AddRange(db.Tema.Where(y => y.tema_pro_mat_id == item.pro_mat_id).ToList());
                }
                List<Asistencia> asistencia = new List<Asistencia>();
                foreach (var item in temas)
                {
                    asistencia.AddRange(db.Asistencia.Where(x => x.asi_tiempo != 0 && x.asi_tema_id == item.tema_id).ToList());
                }
                
                return View(asistencia.ToList());
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/Index" });
           
        }

        // GET: Asistencias/Details/5
       /* public ActionResult Details(int? id)
        {
            if (Request.IsAuthenticated)
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
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/Index" });
            
        }
        */
        // GET: Asistencias/Create
        public ActionResult BuscarAsistencia()
        {
            if (Request.IsAuthenticated)
            {
                string idUser= User.Identity.GetUserId();
                List<Materia> materias = new List<Materia>();
                List<Profesor_Materia> materiasprofesor = db.Profesor_Materia.Where(x => x.pro_mat_pro_id == idUser ).ToList();
                foreach (var item in materiasprofesor)
                {
                    materias.Add(db.Materia.Find(item.pro_mat_mat_id));
                }
                ViewBag.materia = new SelectList(materias.ToList(), "mat_id", "mat_nombre");
                return View();
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/BuscarAsistencia" });


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarAsistencia(Asistencia asistencia)
        {
            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
            {
                return RedirectToAction("TomarLista", new { fecha = asistencia.asi_fecha, idTema=asistencia.asi_tema_id});
            }
            string idUser = User.Identity.GetUserId();
            List<Materia> materias = new List<Materia>();
            List<Profesor_Materia> materiasprofesor = db.Profesor_Materia.Where(x => x.pro_mat_pro_id == idUser).ToList();
            foreach (var item in materiasprofesor)
            {
                materias.Add(db.Materia.Find(item.pro_mat_mat_id));
            }
            ViewBag.materia = new SelectList(materias.ToList(), "mat_id", "mat_nombre");
            return View();
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/Index" });

        }

        public ActionResult TomarLista(DateTime? fecha, int? idTema)
        {
            if (Request.IsAuthenticated)
            {
                if (fecha != null && idTema != null)
            {
                List<Asistencia> estudianteLista = db.Asistencia.Where(x => x.asi_fecha == fecha && x.asi_tema_id == idTema && x.asi_tiempo==0).ToList();

                        Tema tema = db.Tema.Find(estudianteLista.First().asi_tema_id);
                        ViewBag.materia = tema.Profesor_Materia;
                        ViewBag.tema = tema;
                        AsistenciaLista asistenciaLista = new AsistenciaLista();
                        asistenciaLista.asistencias = estudianteLista;
                        asistenciaLista.fecha =(DateTime) fecha;
                        asistenciaLista.horaInicio = estudianteLista.First().asi_hora_inicio;
                        return View(asistenciaLista);
            }
            return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/Index" });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TomarLista(AsistenciaLista asistenciaLista)
        {
            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    TimeSpan time = asistenciaLista.horaFin.Subtract(asistenciaLista.horaInicio).Duration();
                    int tiempo = time.Hours;
                    if (time.Minutes >= 30)
                    {
                        tiempo++;
                    }
                    foreach (var asistencia in asistenciaLista.asistencias)
                    {
                        List<Inscripcion> inscripciones = db.Inscripcion.Where(x => x.ins_est_id == asistencia.asi_est_id).ToList();
                        Inscripcion inscripcion = new Inscripcion();
                        
                        if (inscripciones.Count() != 0)
                        {
                            inscripcion = inscripciones.Last();
                            int saldo = (int)inscripcion.ins_saldo;
                            if (asistencia.asistio)
                            {
                                asistencia.asi_contenido = "Asistio";
                                asistencia.asi_tiempo = tiempo;
                                saldo = saldo - asistencia.asi_tiempo;
                            }
                            else
                            {
                                asistencia.asi_contenido = "Falto";
                                asistencia.asi_tiempo = -1;
                            }

                            asistencia.asi_hora_fin = asistenciaLista.horaFin;
                            if (saldo >= 0)
                            {
                                db.Entry(asistencia).State = EntityState.Modified;
                                db.SaveChanges();
                                inscripcion.ins_saldo = saldo;
                                db.Entry(inscripcion).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }

                    return RedirectToAction("Index");
                }
                
                Tema tema = db.Tema.Find(asistenciaLista.asistencias.First().asi_tema_id);
                ViewBag.materia = tema.Profesor_Materia;
                ViewBag.tema = tema;
               
                return View(asistenciaLista);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/Index" });
        }
        public JsonResult TraerTemasProfesor(int id)
        {
            string idUser = User.Identity.GetUserId();
            IList<Profesor_Materia> profesor_materia = db.Profesor_Materia.Where(t => t.pro_mat_mat_id == id && t.pro_mat_pro_id == idUser).ToList();
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
        public JsonResult TraerHora(int id, string fecha)
        {
            DateTime date = DateTime.Parse(fecha);
            List<Asistencia> asis = new List<Asistencia>();
            List<Asistencia> asistencias = db.Asistencia.Where(x => x.asi_fecha == date && x.asi_tema_id == id && x.asi_tiempo==0).ToList();
            if (asistencias.Count!=0)
            {
                asis.Add(asistencias.First());
            }
            var data = new SelectList(asis.ToList(), "asi_hora_inicio", "asi_hora_inicio");
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // POST: Asistencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        

        // GET: Asistencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.IsAuthenticated)
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
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/Index" });
           
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
            if (Request.IsAuthenticated)
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
            return RedirectToAction("Login", "Account", new { returnUrl = "~/Asistencias/Index" });
            
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

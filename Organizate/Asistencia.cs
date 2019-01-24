//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Organizate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Asistencia
    {
        [DisplayName("Asistencia")]
        public int asi_id { get; set; }
        [DisplayName("Fecha de Asistencia")]
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public System.DateTime asi_fecha { get; set; }
        [DisplayName("Hora de Inicio")]
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Range(typeof(System.TimeSpan), "7:00", "19:00",
        ErrorMessage = "La hora {0} debe estar en el rango de {1} a {2}")]
        public System.TimeSpan asi_hora_inicio { get; set; }
        [DisplayName("Hora de Fin")]
        [Range(typeof(System.TimeSpan), "7:00", "19:00",
        ErrorMessage = "La hora {0} debe estar en el rango de {1} a {2}")]
        public Nullable<System.TimeSpan> asi_hora_fin { get; set; }
        [DisplayName("Tiempo")]
        public int asi_tiempo { get; set; }
        [DisplayName("Contenido")]
        public string asi_contenido { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [DisplayName("Estudiante")]
        public int asi_est_id { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [DisplayName("Tema")]
        public int asi_tema_id { get; set; }

        public virtual Estudiante Estudiante { get; set; }
        public virtual Tema Tema { get; set; }

        public Boolean asistio { get; set; }
    }
    public class AsistenciaLista
    {
        public List<Asistencia> asistencias { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Range(typeof(System.TimeSpan), "7:00", "19:00",
        ErrorMessage = "La hora {0} debe estar en el rango de {1} a {2}")]
        public TimeSpan horaFin { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan horaInicio { get; set; }
    }
}

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

    public partial class Estudiante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estudiante()
        {
            this.Asistencia = new HashSet<Asistencia>();
            this.Inscripcion = new HashSet<Inscripcion>();
        }

        [DisplayName("Estudiante")]
        public int est_id { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [DisplayName("Nombre Estudiante")]
        public string est_nombre { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [DisplayName("Apellido")]
        public string est_apellido { get; set; }
        [MaxLength(15, ErrorMessage = "La propiedad {0} no puede tener más de {1} elementos")]
        [MinLength(7, ErrorMessage = "La propiedad {0} no puede tener al menos de {1} elementos")]
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [DisplayName("Telefono")]
        public string est_telefono { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [DisplayName("Direccion")]
        public string est_direccion { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        //[RegularExpression("\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}\b", ErrorMessage = "No es una direccion de Mail Válida")]
        [EmailAddress(ErrorMessage = "Direccion de Mail Incorrecta")]
        [DisplayName("Correo")]
        public string est_correo { get; set; }
        [MaxLength(10, ErrorMessage = "La propiedad {0} no puede tener más de {1} elementos")]
        [MinLength(10, ErrorMessage = "La propiedad {0} no puede tener menos de {1} elementos")]
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [DisplayName("Cedula")]
        public string est_cedula { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [DisplayName("Establecimiento Educativo")]
        public string est_cole_univ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inscripcion> Inscripcion { get; set; }
    }
}

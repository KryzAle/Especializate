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
    
    public partial class Inscripcion
    {
        public int ins_id { get; set; }
        public System.DateTime ins_fecha { get; set; }
        public double ins_valor { get; set; }
        public int ins_total_horas { get; set; }
        public Nullable<int> ins_saldo { get; set; }
        public int ins_est_id { get; set; }
    
        public virtual Estudiante Estudiante { get; set; }
    }
}

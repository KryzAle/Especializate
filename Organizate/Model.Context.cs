﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_A44489_asistenciaEntities : DbContext
    {
        public DB_A44489_asistenciaEntities()
            : base("name=DB_A44489_asistenciaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Asistencia> Asistencia { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Horario_Profesor> Horario_Profesor { get; set; }
        public virtual DbSet<Inscripcion> Inscripcion { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Profesor_Materia> Profesor_Materia { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }
    }
}
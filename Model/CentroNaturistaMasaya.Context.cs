﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CentroNaturistaMasaya.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CNMEntities : DbContext
    {
        public CNMEntities()
            : base("name=CNMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<ContenidoS> ContenidoS { get; set; }
        public virtual DbSet<ContenidoV> ContenidoV { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Existencia> Existencia { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<PRecetado> PRecetado { get; set; }
        public virtual DbSet<Presentacion> Presentacion { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Suministro> Suministro { get; set; }
        public virtual DbSet<TelefonoP> TelefonoP { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
    }
}
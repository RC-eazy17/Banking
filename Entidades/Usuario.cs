//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Cedula { get; set; }
        public string Contraseña { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public string Email { get; set; }
        public Nullable<int> IdRol { get; set; }
        public Nullable<int> IdEstado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
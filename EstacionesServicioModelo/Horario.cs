//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstacionesServicioModelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horario
    {
        public int Id { get; set; }
        public short Dia { get; set; }
        public System.TimeSpan Inicio { get; set; }
        public Nullable<System.TimeSpan> Duracion { get; set; }
    
        public virtual EstacionServicio EstacionServicio { get; set; }
    }
}

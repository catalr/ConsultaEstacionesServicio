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
    
    public partial class Tarifa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tarifa()
        {
            this.EstacionServicio = new HashSet<EstacionServicio>();
        }
    
        public string codigo { get; set; }
        public Nullable<int> factorValle { get; set; }
        public Nullable<int> factorPunta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstacionServicio> EstacionServicio { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Visitas
    {
        public int id { get; set; }
        public string cedula { get; set; }
        public System.DateTime fecha { get; set; }
        public string motivo { get; set; }
        public string comentario { get; set; }
        public string receta_medicamentos { get; set; }
        public Nullable<System.DateTime> fecha_sig { get; set; }
        public int precio { get; set; }
    
        public virtual Pacientes Pacientes { get; set; }
    }
}

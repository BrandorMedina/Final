using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Models
{
    using System;
    using System.Collections.Generic;

    public class Login
    {
        public int id { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }



        public virtual Doctor Doctor { get; set; }
        public virtual Asistentes Asistentes { get; set; }
    }
}
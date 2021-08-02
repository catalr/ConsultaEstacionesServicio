using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    public class Comuna
    {


        private String Nombre;
        private String region;
        private String Codigo;
        private String Codigo_padre;

        public string nombre { get => Nombre; set => Nombre = value; }
        public string codigo { get => Codigo; set => Codigo = value; }
        internal string Region { get => region; set => region = value; }
        public string codigo_padre { get => Codigo_padre; set => Codigo_padre = value;}
    }
}

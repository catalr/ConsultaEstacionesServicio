using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    public class Region
    {
        private String Codigo;
        private String Nombre;
        private int cod;

        public String codigo { get => Codigo; set => Codigo = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public int Cod { get => Int32.Parse(Codigo); set => cod = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesServicioModelo
{
    public partial class Direccion
    {
        public override string ToString()
        {
            return calle + " #" + nro;
        }
    }
}

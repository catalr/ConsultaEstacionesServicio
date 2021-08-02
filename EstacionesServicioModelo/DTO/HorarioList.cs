using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesServicioModelo
{
    public partial class Horario
    {
        public override string ToString()
        {
            String[] dias = new String[7] { "LU", "MA", "MI", "JU", "VI", "SA", "DO" };
            DateTime inicio = DateTime.Today.Add(Inicio);
            DateTime cierre = DateTime.Today.Add(Inicio + Duracion.Value);
            String horario = inicio.ToString("HH:mm") + "-" + cierre.ToString("HH:mm");
            return dias[Dia] + ": " + horario;
        }
    }
}

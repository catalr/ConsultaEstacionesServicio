using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesServicioModelo
{
    public partial class EstacionServicio
    {
        public String HorarioList
        {
            get
            {
                List<Horario> horarios = Horario.ToList(); ;
                String[] horariosDiarios = new String[7] { "", "", "", "", "", "", "" };
                String[] dias = new String[7] { "LU", "MA", "MI", "JU", "VI", "SA", "DO" };
                foreach (Horario h in horarios)
                {
                    short dia = h.Dia;
                    DateTime inicio = DateTime.Today.Add(h.Inicio);
                    DateTime cierre = DateTime.Today.Add(h.Inicio + h.Duracion.Value);
                    String horario = inicio.ToString("HH:mm") + "-" + cierre.ToString("HH:mm");
                    if (!String.IsNullOrEmpty(horariosDiarios[dia]))
                        horariosDiarios[dia] += ", ";
                    horariosDiarios[dia] += horario;
                }
                String ans = "";
                for (int i = 1; i < 7; i++)
                {
                    if (!String.IsNullOrEmpty(horariosDiarios[i - 1]))
                    {
                        if (horariosDiarios[i].Equals(horariosDiarios[i - 1]))
                        {
                            string start = dias[i-1];
                            while (i<7 && horariosDiarios[i].Equals(horariosDiarios[i - 1]) )
                            {
                                i++;
                            }
                            string end = dias[i-1];
                            if (!String.IsNullOrEmpty(ans))
                                ans += ", ";
                            ans += start + "-" + end + ": " + horariosDiarios[i - 1];
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(ans))
                                ans += ", ";
                            ans += dias[i-1] + ": " + horariosDiarios[i - 1];
                        }
                    }
                }
                return ans;
            }

        }

    }
}

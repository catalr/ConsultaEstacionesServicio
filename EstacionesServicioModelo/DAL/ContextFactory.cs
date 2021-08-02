using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesServicioModelo.DAL
{
    public class ContextFactory
    {
        private static BDEntities contexto;

        public static BDEntities getContexto()
        {
            if (contexto == null)
                contexto = new BDEntities();
            return contexto;
        }
    }
}

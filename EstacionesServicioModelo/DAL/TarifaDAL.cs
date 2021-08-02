
using EstacionesServicioModelo;
using System.Collections.Generic;
using System.Linq;

namespace EstacionesServicioModelo.DAL
{
    public class TarifaDAL
    {
        public BDEntities bdEntities = ContextFactory.getContexto();

        public TarifaDAL()
        {
            if (!bdEntities.Tarifa.ToList().Any())
            {
                bdEntities.Tarifa.Add(new Tarifa
                {
                    codigo = "tar123",
                    factorValle = 123,
                    factorPunta = 150
                });
                bdEntities.Tarifa.Add(new Tarifa
                {
                    codigo = "tar143",
                    factorValle = 133,
                    factorPunta = 154
                });
                bdEntities.Tarifa.Add(new Tarifa
                {
                    codigo = "tar154",
                    factorValle = 125,
                    factorPunta = 154
                });
                bdEntities.Tarifa.Add(new Tarifa
                {
                    codigo = "tar234",
                    factorValle = 121,
                    factorPunta = 156
                });
                bdEntities.SaveChanges();
            }
        }

        public List<Tarifa> getAll()
        {
            return bdEntities.Tarifa.ToList();
        }

        public Tarifa getTarifa(string codTarifa)
        {
            return bdEntities.Tarifa.Find(codTarifa);
        }
    }

}

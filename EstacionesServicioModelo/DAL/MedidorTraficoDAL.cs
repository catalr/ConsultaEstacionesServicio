using System;
using System.Collections.Generic;
using System.Linq;
using EstacionesServicioModelo;

namespace EstacionesServicioModelo.DAL
{
    public class MedidorTraficoDAL
    {
        private BDEntities bdEntities = ContextFactory.getContexto();

        public MedidorTraficoDAL()
        {
            if (!ObtenerMedidores().Any())
            {
                bdEntities.MedidorTrafico.Add(new MedidorTrafico()
                { 
                    Medidor = new Medidor()
                    {
                        id = 7,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.MedidorTrafico.Add(new MedidorTrafico()
                {
                    Medidor = new Medidor()
                    {
                        id = 8,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.MedidorTrafico.Add(new MedidorTrafico()
                {
                    Medidor = new Medidor()
                    {
                        id = 9,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.MedidorTrafico.Add(new MedidorTrafico()
                {
                    Medidor = new Medidor()
                    {
                        id = 10,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.MedidorTrafico.Add(new MedidorTrafico()
                {
                    Medidor = new Medidor()
                    {
                        id = 11,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.MedidorTrafico.Add(new MedidorTrafico()
                {
                    Medidor = new Medidor()
                    {
                        id = 12,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.SaveChanges();
            }
            else
            {
                Console.WriteLine(bdEntities.Medidor.FirstOrDefault().id);
            }
        }

     
        public MedidorTrafico Get(int id)
        {
            return bdEntities.MedidorTrafico.Find(id);
        }



        public List<MedidorTrafico> ObtenerMedidores()
        {

            return bdEntities.MedidorTrafico.ToList();
        }
    }
}

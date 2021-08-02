using System;
using System.Collections.Generic;
using System.Linq;
using EstacionesServicioModelo;

namespace EstacionesServicioModelo.DAL
{
    public class MedidorConsumoDAL
    {
        private BDEntities bdEntities = ContextFactory.getContexto();

        public MedidorConsumoDAL()
        {
            if (!ObtenerMedidores().Any())
            {
                bdEntities.MedidorConsumo.Add(new MedidorConsumo()
                {
                    Medidor = new Medidor()
                    {
                        id = 1,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.MedidorConsumo.Add(new MedidorConsumo()
                {
                    Medidor = new Medidor()
                    {
                        id = 2,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.MedidorConsumo.Add(new MedidorConsumo()
                {
                    Medidor = new Medidor()
                    {
                        id = 3,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.MedidorConsumo.Add(new MedidorConsumo()
                {
                    Medidor = new Medidor()
                    {
                        id = 4,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.MedidorConsumo.Add(new MedidorConsumo()
                {
                    Medidor = new Medidor()
                    {
                        id = 5,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.MedidorConsumo.Add(new MedidorConsumo()
                {
                    Medidor = new Medidor()
                    {
                        id = 6,
                        fechaInstalacion = DateTime.Now
                    }
                });
                bdEntities.SaveChanges();
            }
        }


        public MedidorConsumo Get(int id)
        {
            return bdEntities.MedidorConsumo.Find(id);
        }



        public List<MedidorConsumo> ObtenerMedidores()
        {

            return bdEntities.MedidorConsumo.ToList();
        }
    }
    }
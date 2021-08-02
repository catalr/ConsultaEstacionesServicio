using EstacionesServicioModelo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;

namespace EstacionesServicioModelo.DAL
{
    public class PuntoCargaDAL
    {
        private BDEntities bdEntities = ContextFactory.getContexto();
        private EstacionServicioDAL estDal = new EstacionServicioDAL();
        private MedidorTraficoDAL medTrafDal = new MedidorTraficoDAL();
        private MedidorConsumoDAL medConsDal = new MedidorConsumoDAL();


        public PuntoCargaDAL()
        {
            if (!ObtenerPuntosCarga().Any())
            {
                
                bdEntities.PuntoCarga.Add(new PuntoCarga
                {
                    id = 1,
                    capacidadMaxima = 5,
                    fechaVencimiento = DateTime.Today,
                    EstacionServicio1 = estDal.ObtenerEstacion(1790630),
                    esDual = true,
                    MedidorConsumo = medConsDal.Get(1),
                    MedidorTrafico = medTrafDal.Get(7)
                });
               
                
                bdEntities.PuntoCarga.Add(new PuntoCarga
                {
                    id = 2,
                    capacidadMaxima = 5,
                    fechaVencimiento = DateTime.Today,
                    EstacionServicio1 = estDal.ObtenerEstacion(1790630),
                    esDual = false,
                    MedidorConsumo = medConsDal.Get(2),
                    MedidorTrafico = medTrafDal.Get(8)
                });
                
                bdEntities.PuntoCarga.Add(new PuntoCarga
                {
                    id = 3,
                    capacidadMaxima = 5,
                    fechaVencimiento = DateTime.Today,
                    EstacionServicio1 = estDal.ObtenerEstacion(6211560),
                    esDual = false,
                    MedidorConsumo = medConsDal.Get(3),
                    MedidorTrafico = medTrafDal.Get(9)
                });
                
                bdEntities.PuntoCarga.Add(new PuntoCarga
                {
                    id = 4,
                    capacidadMaxima = 5,
                    fechaVencimiento = DateTime.Today,
                    EstacionServicio1 = estDal.ObtenerEstacion(6211560),
                    esDual = true,
                    MedidorConsumo = medConsDal.Get(4),
                    MedidorTrafico = medTrafDal.Get(10)
                });
                
                bdEntities.PuntoCarga.Add(new PuntoCarga
                {
                    id = 5,
                    capacidadMaxima = 5,
                    fechaVencimiento = DateTime.Today,
                    EstacionServicio1 = estDal.ObtenerEstacion(3581634),
                    esDual = false,
                    MedidorConsumo = medConsDal.Get(5),
                    MedidorTrafico = medTrafDal.Get(11)
                });
                
                bdEntities.PuntoCarga.Add(new PuntoCarga
                {
                    id = 6,
                    capacidadMaxima = 5,
                    fechaVencimiento = DateTime.Today,
                    EstacionServicio1 = estDal.ObtenerEstacion(3581634),
                    esDual = true,
                    MedidorConsumo = medConsDal.Get(6),
                    MedidorTrafico = medTrafDal.Get(12)
                });
                bdEntities.SaveChanges();

            }
            
        }


        public PuntoCarga ActualizaPunto(PuntoCarga punto)
        {
            var amodificar = bdEntities.PuntoCarga.Find(punto.id);
            amodificar.capacidadMaxima = punto.capacidadMaxima;
            amodificar.esDual = punto.esDual;
            amodificar.fechaVencimiento = punto.fechaVencimiento;
            bdEntities.SaveChanges();
            return bdEntities.PuntoCarga.Find(punto.id);

        }

        public List<PuntoCarga> ObtenerPuntosCarga()
        {
            return bdEntities.PuntoCarga.ToList();
        }

        public List<PuntoCarga> ObtenerPuntosCargaElectricos()
        {
            var puntos = bdEntities.PuntoCarga
                .Where(p => (bool)!p.esDual).ToList();
            return puntos;
        }

        public List<PuntoCarga> ObtenerPuntosCargaDuales()
        {
            var puntos = bdEntities.PuntoCarga
                .Where(p => (bool)p.esDual).ToList();
            return puntos;
        }

        public PuntoCarga RegistrarPunto(PuntoCarga punto)
        {
            try
            {
                bdEntities.PuntoCarga.Add(punto);
                bdEntities.SaveChanges();
            }
            catch (UpdateException ex)
            {
                SqlException innerException = ex.InnerException as SqlException;
                if (innerException == null || innerException.Number != 2601)
                {
                    throw;
                    //else is a duplicate entry exception and i should be able to call
                    //return bdEntities.PuntoCarga.Find(punto.Id); w/o another exeption and it would
                    //return the existing object in the DB, then i can check if punto != registarPunto(punto)
                    //id ya existia, no se puede usar una id repetida.
                }
            }
            return bdEntities.PuntoCarga.Find(punto.id);
        }

        public List<PuntoCarga> ObtenerPuntosCarga(EstacionServicio estacion)
        {
            return bdEntities.PuntoCarga.ToList();
        }
    }
}

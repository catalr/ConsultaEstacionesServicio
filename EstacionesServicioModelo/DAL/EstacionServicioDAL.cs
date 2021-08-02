using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using EstacionesServicioModelo;

namespace EstacionesServicioModelo.DAL
{
    public class EstacionServicioDAL
    {
        private BDEntities contexto = ContextFactory.getContexto();
        public String[] regiones = {  //dont @ me, this is kind of nasty
                "Arica y Parinacota",
                "Tarapacá",
                "Antofagasta",
                "Atacama",
                "Coquimbo",
                "Valparaiso",
                "Metropolitana",
                "O'Higgins",
                "Maule",
                "Ñuble",
                "Biobío",
                "Araucanía",
                "Los Ríos",
                "Los Lagos",
                "Aysén",
                "Magallanes"
            };
        /// <summary>
        /// 
        /// </summary>
        public EstacionServicioDAL(){
            if (!contexto.EstacionServicio.Any())
            {
                List<Tarifa> tarifas = new TarifaDAL().getAll();

                Random random = new Random();
                EstacionServicio nueva1 = new EstacionServicio
                {
                    Tarifa1 = tarifas[random.Next(tarifas.Count)],
                    capacidadMaxima = 20,
                    Direccion1 = new Direccion
                    {
                        codPostal = 1790630,
                        calle = "Avenida Circunvalacion Salvador Allende Gossens", //swear this was a coincidence
                        comuna = "Coquimbo",
                        nro = 444,
                        region = regiones[4]
                    }

                };
                contexto.EstacionServicio.Add(nueva1);

                EstacionServicio nueva2 = new EstacionServicio
                {
                    Tarifa1 = tarifas[random.Next(tarifas.Count)],
                    capacidadMaxima = 20,
                    Direccion1 = new Direccion
                    {
                        codPostal = 6211560,
                        calle = "AVENIDA PRESIDENTE EDUARDO FREI MONTALVA", // this was also a coincidence
                        comuna = "Punta Arenas",
                        nro = 314,
                        region = regiones[15]
                    }

                };
                contexto.EstacionServicio.Add(nueva2);
                contexto.SaveChanges();
                contexto.EstacionServicio.Add(new EstacionServicio
                {
                    Tarifa1 = tarifas[random.Next(tarifas.Count)],
                    capacidadMaxima = 20,
                    Direccion1 = new Direccion
                    {

                        codPostal = 6211560,
                        calle = "AVENIDA PRESIDENTE EDUARDO FREI MONTALVA", // this was also a coincidence
                        comuna = "Punta Arenas",
                        nro = 314,
                        region = regiones[15]
                    }

                });
                contexto.EstacionServicio.Add(new EstacionServicio
                {
                    Tarifa1 = tarifas[random.Next(tarifas.Count)],
                    capacidadMaxima = 20,
                    Direccion1 = new Direccion
                    {
                        codPostal = 3581634,
                        calle = "Avenida Anibal Leon Bustos",
                        comuna = "Linares",
                        nro = 1052,
                        region = regiones[9]
                    }

                });
                contexto.SaveChanges();
            }
        }
              


       
        public List<EstacionServicio> ObtenerEstaciones()
        {
            return contexto.EstacionServicio.ToList();
        }

        public EstacionServicio RegistrarEstacion(EstacionServicio estacion)
        {
            try
            {
                contexto.EstacionServicio.Add(estacion);
                contexto.SaveChanges();
            }
            catch (UpdateException ex)
            {
                SqlException innerException = ex.InnerException as SqlException;
                if (innerException == null || innerException.Number != 2601)
                {
                    throw;
                }
            }
            return contexto.EstacionServicio.Find(estacion.Id);
        }

        public void EliminarEstacion(int id)
        {
            EstacionServicio aEliminar = contexto.EstacionServicio.Find(id);
            contexto.EstacionServicio.Remove(aEliminar);
            contexto.SaveChanges();
            return;
        }

        public void EliminarEstacion(EstacionServicio estacion)
        {
            EstacionServicio aEliminar = contexto.EstacionServicio.Find(estacion.Id);
            contexto.EstacionServicio.Remove(aEliminar);
            contexto.SaveChanges();
            return;
        }

        public List<EstacionServicio> ObtenerEstacionesRegion(string region)
        {
            return contexto.EstacionServicio.Where(x => x.Direccion1.region == region).ToList();
        }

        public List<EstacionServicio> ObtenerEstacionesComuna(string comuna)
        {
            return contexto.EstacionServicio.Where(x => x.Direccion1.comuna == comuna).ToList();
        }

        public List<EstacionServicio> ObtenerEstaciones(List<Direccion> direcciones)
        {
            List<EstacionServicio> respuesta = new List<EstacionServicio>();
            foreach(Direccion d in direcciones)
            {
                EstacionServicio toAdd = ObtenerEstacion(d);
                if (toAdd != null)
                    respuesta.Add(toAdd);
            }
            return respuesta;
        }

        public EstacionServicio ObtenerEstacion(Direccion direccion)
        {
            return contexto.EstacionServicio.Where(x => x.Direccion1 == direccion).FirstOrDefault();
        }

        public List<EstacionServicio> ObtenerEstaciones(List<int> codPostal)
        {
            List<EstacionServicio> respuesta = new List<EstacionServicio>();
            foreach (int d in codPostal)
            {
                EstacionServicio toAdd = ObtenerEstacion(d);
                if (toAdd != null)
                    respuesta.Add(toAdd);
            }
            return respuesta;
        }

        public EstacionServicio ObtenerEstacion(int codPostal)
        {
            return contexto.EstacionServicio.Where(x => x.Direccion1.codPostal == codPostal).FirstOrDefault();
        }

        public EstacionServicio ActualizarEstacion(EstacionServicio estacion)
        {
            EstacionServicio amodificar = contexto.EstacionServicio.Find(estacion.Id);
            amodificar.Direccion1 = estacion.Direccion1;
            amodificar.capacidadMaxima = estacion.capacidadMaxima;
            amodificar.Tarifa1 = estacion.Tarifa1;
            contexto.SaveChanges();
            return contexto.EstacionServicio.Find(estacion.Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TalentoUAQWebService.Models
{
    public class EscolaridadesRepository
    {
        private static TalentoUAQEntities dataContext = new TalentoUAQEntities();

        public static tblescolaridade guardarEscolaridades(tblescolaridade data)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            tblescolaridade respuesta;
            if (data.idEscolaridad == 0)
            {
                tblescolaridade escolaridad = new tblescolaridade
                {
                    carrera = data.carrera,
                    escuela = data.escuela,
                    fechaFin = data.fechaFin,
                    fechaInicio = data.fechaInicio,
                    idAspirante = data.idAspirante,
                    activo = "S",
                    fechaRegistro = DateTime.Now,
                    fechaActualizacion = DateTime.Now
                };
                respuesta = dataContext.tblescolaridades.Add(escolaridad);
                dataContext.SaveChanges();
            }
            else
            {
                var query = (from tblescolaridade in dataContext.tblescolaridades
                             select tblescolaridade);
                query = query.Where(a => a.idEscolaridad == data.idEscolaridad);
                var fav = query.First();
                fav.activo = data.activo;
                fav.carrera = data.carrera;
                fav.escuela = data.escuela;
                fav.fechaInicio = data.fechaInicio;
                fav.fechaFin = data.fechaFin;
                fav.activo = data.activo;
                fav.fechaActualizacion = DateTime.Now;
                respuesta = fav;
                dataContext.SaveChanges();
            }

            return respuesta;
        }
    }
}
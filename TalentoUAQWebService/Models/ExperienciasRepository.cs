using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TalentoUAQWebService.Models
{
    public class ExperienciasRepository
    {
        private static TalentoUAQEntities dataContext = new TalentoUAQEntities();

        public static tblexperiencia guardarExperiencia(tblexperiencia data)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            tblexperiencia respuesta;
            if (data.idExperiencia == 0)
            {
                tblexperiencia experiencia = new tblexperiencia
                {
                    cargo = data.cargo,
                    fechaFin = data.fechaFin,
                    fechaInicio = data.fechaInicio,
                    idAspirante = data.idAspirante,
                    institucion = data.institucion,
                    activo = "S",
                    fechaRegistro = DateTime.Now,
                    fechaActualizacion = DateTime.Now
                };
                respuesta = dataContext.tblexperiencias.Add(experiencia);
                dataContext.SaveChanges();
            }
            else
            {
                var query = (from tblexperiencia in dataContext.tblexperiencias
                             select tblexperiencia);
                query = query.Where(a => a.idExperiencia == data.idExperiencia);
                var fav = query.First();
                fav.activo = data.activo;
                fav.cargo = data.cargo;
                fav.fechaFin = data.fechaFin;
                fav.fechaInicio = data.fechaInicio;
                fav.institucion = data.institucion;
                fav.fechaActualizacion = DateTime.Now;
                respuesta = fav;
                dataContext.SaveChanges();
            }

            return respuesta;
        }
    }
}
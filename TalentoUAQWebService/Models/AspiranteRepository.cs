using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TalentoUAQWebService.Models
{
    public class AspiranteRepository
    {
        private static TalentoUAQEntities dataContext = new TalentoUAQEntities();

        public static tblaspirante guardarAspirante(tblaspirante data)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            tblaspirante respuesta;
            if (data.idAspirante == 0)
            {
                tblaspirante aspirante = new tblaspirante
                {
                    idUsuarioExterno = data.idUsuarioExterno,
                    telefono = data.telefono,
                    email = data.email,
                    objetivo = data.objetivo,
                    sueldoDeseado = data.sueldoDeseado,                    
                    activo = "S",
                    fechaRegistro = DateTime.Now,
                    fechaActualizacion = DateTime.Now
                };
                respuesta = dataContext.tblaspirantes.Add(aspirante);
                dataContext.SaveChanges();
            }
            else
            {
                var query = (from tblaspirante in dataContext.tblaspirantes
                             select tblaspirante);
                query = query.Where(a => a.idAspirante == data.idAspirante);
                var asp = query.First();
                asp.activo = data.activo;
                asp.objetivo = data.objetivo;
                asp.sueldoDeseado = data.sueldoDeseado;
                asp.email = data.email;
                asp.telefono = data.telefono;
                asp.fechaActualizacion = DateTime.Now;
                respuesta = asp;
                dataContext.SaveChanges();
            }

            return respuesta;
        }
    }
}
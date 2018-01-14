using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TalentoUAQWebService.Models
{
    public class IdiomasRepository
    {
        private static TalentoUAQEntities dataContext = new TalentoUAQEntities();

        public static tblidioma guardarIdioma(tblidioma data)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            tblidioma respuesta;
            if (data.idIdioma == 0)
            {
                tblidioma idioma = new tblidioma
                {
                    idAspirante = data.idAspirante,
                    idioma = data.idioma,
                    activo = "S",
                    fechaRegistro = DateTime.Now,
                    fechaActualizacion = DateTime.Now
                };
                respuesta = dataContext.tblidiomas.Add(idioma);
                dataContext.SaveChanges();
            }
            else
            {
                var query = (from tblidioma in dataContext.tblidiomas
                             select tblidioma);
                query = query.Where(a => a.idIdioma == data.idIdioma);
                var fav = query.First();
                fav.activo = data.activo;
                fav.idioma = data.idioma;
                fav.fechaActualizacion = DateTime.Now;
                respuesta = fav;
                dataContext.SaveChanges();
            }

            return respuesta;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TalentoUAQWebService.Models
{
    public class FavoritosRepository
    {
        private static TalentoUAQEntities dataContext = new TalentoUAQEntities();

        public static tblfavorito GuardarFavorito(tblfavorito data)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            tblfavorito respuesta;
            if (data.idFavorito == 0)
            {
                tblfavorito favorito = new tblfavorito
                {
                    idUsuarioExterno = data.idUsuarioExterno,
                    idOferta = data.idOferta,
                    activo = "S",
                    fechaRegistro = DateTime.Now,
                    fechaActualizacion = DateTime.Now
                };
                respuesta = dataContext.tblfavoritos.Add(favorito);
                dataContext.SaveChanges();
            }
            else {
                var query = (from tblfavorito in dataContext.tblfavoritos                             
                             select tblfavorito);
                query = query.Where(a => a.idFavorito == data.idFavorito);
                var fav = query.First();
                fav.activo = data.activo;
                fav.fechaActualizacion = DateTime.Now;
                respuesta = fav;
                dataContext.SaveChanges();
            }

            return respuesta;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TalentoUAQWebService.Models
{
    public class SubCategoriasUsuarioRepository
    {
        private static TalentoUAQEntities dataContext = new TalentoUAQEntities();

        public static tblsubcategoriasusuario GuardarSubCategoriaUsuario(tblsubcategoriasusuario data)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            tblsubcategoriasusuario respuesta;
            if (data.idSubcategoriaUsuario == 0)
            {
                tblsubcategoriasusuario subcategoriausuario = new tblsubcategoriasusuario
                {
                    cveSubcategoria = data.cveSubcategoria,
                    idUsuarioExterno = data.idUsuarioExterno,                    
                    activo = "S",
                    fechaRegistro = DateTime.Now,
                    fechaActualizacion = DateTime.Now
                };
                respuesta = dataContext.tblsubcategoriasusuarios.Add(subcategoriausuario);
                dataContext.SaveChanges();
            }
            else
            {
                var query = (from tblsubcategoriasusuario in dataContext.tblsubcategoriasusuarios
                             select tblsubcategoriasusuario);
                query = query.Where(a => a.idSubcategoriaUsuario == data.idSubcategoriaUsuario);
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
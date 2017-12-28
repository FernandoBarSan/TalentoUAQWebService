using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentoAUQService.Models
{
    public class TalentoRepository
    {
        private static TalentoUAQEntities dataContext = new TalentoUAQEntities();
        public static List<tblcategoria> GetCategorias()
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblcategoria in dataContext.tblcategorias
                        where tblcategoria.activo=="S"
                        select tblcategoria;
            return query.ToList();
        }

        public static tblcategoria GetCategoriaById(int cveCategoria)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblcategorias in dataContext.tblcategorias
                        where tblcategorias.cveCategoria == cveCategoria && tblcategorias.activo=="S"
                        select tblcategorias;
            return query.SingleOrDefault();
        }

        public static List<tblsubcategoria> GetSubcategoria()
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblsubcategorias in dataContext.tblsubcategorias
                        where tblsubcategorias.activo=="S"
                        select tblsubcategorias;
            return query.ToList();
        }

        public static tblsubcategoria GetSubcategoriaById(int cveSubcategoria)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblsubcategorias in dataContext.tblsubcategorias
                        where tblsubcategorias.cveSubcategoria == cveSubcategoria && tblsubcategorias.activo=="S"
                        select tblsubcategorias;
            return query.SingleOrDefault();
        }

        public static List<tblsubcategoria> GetSubcategoriaByCategoria(int cveCategoria)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblsubcategorias in dataContext.tblsubcategorias
                        where tblsubcategorias.cveCategoria == cveCategoria && tblsubcategorias.activo=="S"
                        select tblsubcategorias;
            return query.ToList();
        }

        public static List<tblestado> GetEstado()
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblestados in dataContext.tblestados
                        where tblestados.activo=="S"
                        select tblestados;
            return query.ToList();
        }

        public static List<tblestado> GetEstadoById(int cveEstado)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblestados in dataContext.tblestados
                        where tblestados.cveEstado == cveEstado && tblestados.activo=="S"
                        select tblestados;
            return query.ToList();
        }

        public static List<tblestado> GetMunicipio()
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblestados in dataContext.tblestados
                        where tblestados.activo=="S"
                        select tblestados;
            return query.ToList();
        }

        public static List<tblmunicipio> GetMunicipioById(int cveMunicipio)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblmunicipios in dataContext.tblmunicipios
                        where tblmunicipios.cveMunicipio == cveMunicipio && tblmunicipios.activo =="S"
                        select tblmunicipios;
            return query.ToList();
        }

        public static List<tblmunicipio> GetMunicipioByIdEstado(int cveEstado)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblmunicipios in dataContext.tblmunicipios
                        where tblmunicipios.cveEstado == cveEstado && tblmunicipios.activo=="S"
                        select tblmunicipios;
            query.Where(a => a.activo == "S");
            return query.ToList();
        }

        public static List<tblempresa> GetEmpresa()
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblempresas in dataContext.tblempresas
                        where tblempresas.activo == "S"
                        select tblempresas;
            return query.ToList();
        }

        public static List<tblempresa> GetEmpresaById(int cveEmpresa)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblempresas in dataContext.tblempresas
                        where tblempresas.cveEmpresa == cveEmpresa && tblempresas.activo == "S"
                        select tblempresas;
            return query.ToList();
        }

        public static List<tbloferta> GetFavorito()
        {
            favoritosClass favorit = new favoritosClass();
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tbloferta in dataContext.tblofertas
                        join tblfavoritos in dataContext.tblfavoritos on tbloferta.idOferta equals tblfavoritos.idOferta
                        join tblsubcategoria in dataContext.tblsubcategorias on tbloferta.cveSubcategoria equals tblsubcategoria.cveSubcategoria
                        where tbloferta.activo=="S" && tblfavoritos.activo=="S"
                        select tblfavoritos.tbloferta as tbloferta;
            query.Where(a => a.activo == "S");
            favorit.oferta = query.ToList();
            return query.ToList();
        }

        public static List<tbloferta> GetFavoritoById(int idUsuarioExterno)
        {
            favoritosClass favorit = new favoritosClass();
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tbloferta in dataContext.tblofertas join tblfavoritos in dataContext.tblfavoritos on  tbloferta.idOferta equals tblfavoritos.idOferta 
                        where tblfavoritos.idUsuarioExterno == idUsuarioExterno && tblfavoritos.activo == "S" && tbloferta.fechaFinOferta >= DateTime.Today && tbloferta.activo == "S"
                        select tbloferta ;

            favorit.oferta = query.ToList();
            return query.ToList();
        }

        public static List<tbloferta> GetSugerenciasById(int idUsuarioExterno)
        {
            favoritosClass favorit = new favoritosClass();
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblsubcategoriasusuario in dataContext.tblsubcategoriasusuarios
                        join tblsubcategoria in dataContext.tblsubcategorias on tblsubcategoriasusuario.cveSubcategoria equals tblsubcategoria.cveSubcategoria
                        join tbloferta in dataContext.tblofertas on tblsubcategoria.cveSubcategoria equals tbloferta.cveSubcategoria
                        where tblsubcategoriasusuario.idUsuarioExterno == idUsuarioExterno && tbloferta.activo == "S" && tbloferta.fechaFinOferta >= DateTime.Today && tblsubcategoria.activo == "S" && tblsubcategoriasusuario.activo=="S"
                        select tbloferta;

            favorit.oferta = query.ToList();
            return query.ToList();
        }

        public static DatosGenerales GetDatosGeneralesById(int idUsuarioExterno)
        {
            DatosGenerales DatosG = new DatosGenerales();
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblaspirante in dataContext.tblaspirantes
                        where tblaspirante.idUsuarioExterno == idUsuarioExterno && tblaspirante.activo == "S" 
                        select tblaspirante;

            DatosG.aspirante = query.ToList();
            foreach (tblaspirante aspirante in DatosG.aspirante) {
                var query2 = from tblexperiencia in dataContext.tblexperiencias
                            where tblexperiencia.idAspirante == aspirante.idAspirante.ToString() && tblexperiencia.activo == "S"
                            select tblexperiencia;
                DatosG.experiencias = query2.ToList();
                var query3 = from tblescolaridade in dataContext.tblescolaridades
                             where tblescolaridade.idAspirante == aspirante.idAspirante && tblescolaridade.activo == "S"
                             select tblescolaridade;
                DatosG.escoladirades = query3.ToList();
                var query4 = from tblidioma in dataContext.tblidiomas
                             where tblidioma.idAspirante == aspirante.idAspirante && tblidioma.activo == "S"
                             select tblidioma;
                DatosG.idiomas = query4.ToList();
            }
            return DatosG;
        }


        //select * from tblsubcategoriasusuarios subc join tblsubcategorias sub on (subc.cveSubcategoria=sub.cveSubcategoria) join tblofertas ofe on (ofe.cveSubcategoria=sub.cveSubcategoria);
    }
}
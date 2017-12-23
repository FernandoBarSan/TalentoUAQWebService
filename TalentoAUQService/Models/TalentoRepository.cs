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
                        select tblcategoria;
            return query.ToList();
        }

        public static tblcategoria GetCategoriaById(int cveCategoria)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblcategorias in dataContext.tblcategorias
                        where tblcategorias.cveCategoria == cveCategoria
                        select tblcategorias;
            return query.SingleOrDefault();
        }

        public static List<tblsubcategoria> GetSubcategoria()
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblsubcategorias in dataContext.tblsubcategorias
                        select tblsubcategorias;
            return query.ToList();
        }

        public static tblsubcategoria GetSubcategoriaById(int cveSubcategoria)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblsubcategorias in dataContext.tblsubcategorias
                        where tblsubcategorias.cveSubcategoria == cveSubcategoria
                        select tblsubcategorias;
            return query.SingleOrDefault();
        }

        public static List<tblsubcategoria> GetSubcategoriaByCategoria(int cveCategoria)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblsubcategorias in dataContext.tblsubcategorias
                        where tblsubcategorias.cveCategoria == cveCategoria
                        select tblsubcategorias;
            return query.ToList();
        }

        public static List<tblestado> GetEstado()
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblestados in dataContext.tblestados
                        select tblestados;
            return query.ToList();
        }

        public static List<tblestado> GetEstadoById(int cveEstado)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblestados in dataContext.tblestados
                        where tblestados.cveEstado == cveEstado
                        select tblestados;
            return query.ToList();
        }

        public static List<tblestado> GetMunicipio()
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblestados in dataContext.tblestados
                        select tblestados;
            return query.ToList();
        }

        public static List<tblmunicipio> GetMunicipioById(int cveMunicipio)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblmunicipios in dataContext.tblmunicipios
                        where tblmunicipios.cveMunicipio == cveMunicipio
                        select tblmunicipios;
            return query.ToList();
        }

        public static List<tblmunicipio> GetMunicipioByIdEstado(int cveEstado)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblmunicipios in dataContext.tblmunicipios
                        where tblmunicipios.cveEstado == cveEstado
                        select tblmunicipios;
            return query.ToList();
        }

        public static List<tblempresa> GetEmpresa()
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblempresas in dataContext.tblempresas
                        select tblempresas;
            return query.ToList();
        }

        public static List<tblempresa> GetEmpresaById(int cveEmpresa)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblempresas in dataContext.tblempresas
                        where tblempresas.cveEmpresa == cveEmpresa
                        select tblempresas;
            return query.ToList();
        }

        public static List<tblfavorito> GetFavorito()
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblfavoritos in dataContext.tblfavoritos
                        select tblfavoritos;
            return query.ToList();
        }

        public static List<tblfavorito> GetFavoritoById(int idFavorito)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblfavoritos in dataContext.tblfavoritos
                        where tblfavoritos.idFavorito == idFavorito
                        select tblfavoritos;
            return query.ToList();
        }

    }
}
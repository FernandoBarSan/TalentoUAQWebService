using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentoUAQWebService.Models
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

        public static List<OfertaResult> GetFavorito()
        {
            //dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tbloferta in dataContext.tblofertas
                        join tblfavoritos in dataContext.tblfavoritos on tbloferta.idOferta equals tblfavoritos.idOferta
                        join tblsubcategoria in dataContext.tblsubcategorias on tbloferta.cveSubcategoria equals tblsubcategoria.cveSubcategoria
                        join tblmunicipio in dataContext.tblmunicipios on tbloferta.cveMunicipio equals tblmunicipio.cveMunicipio
                        join tblestado in dataContext.tblestados on tblmunicipio.cveEstado equals tblestado.cveEstado
                        join tblcategoria in dataContext.tblcategorias on tblsubcategoria.cveCategoria equals tblcategoria.cveCategoria
                        join tbltiposempleo in dataContext.tbltiposempleos on tbloferta.cveTipoEmpleo equals tbltiposempleo.cveTipoEmpleo
                        join tblempresa in dataContext.tblempresas on tbloferta.cveEmpresa equals tblempresa.cveEmpresa 
                        where tbloferta.activo=="S" && tblfavoritos.activo=="S"
                        select tbloferta ;
            query.Where(a => a.activo == "S");

            var lista = query.ToList();
            var listaResult = new List<OfertaResult>();
                foreach (tbloferta element in lista)
                {
                    var nombreDos = element.tblempresa;
                    listaResult.Add(new OfertaResult
                    {
                        idOferta = element.idOferta.ToString(),
                        titulo = element.titulo.ToString(),
                        descripcion = element.descripcion.ToString(),
                        sueldoInicio = element.sueldoInicio.ToString(),
                        sueldoFin = element.sueldoFin.ToString(),
                        fechaInicioOferta = element.fechaInicioOferta.ToString(),
                        fechaFinOferta = element.fechaFinOferta.ToString(),
                        cveEmpresa = element.cveEmpresa.ToString(),
                        nombreEmpresa = element.tblempresa.nombre.ToString(),
                        nombreContacto = element.nombreContacto.ToString(),
                        correoContacto = element.correoContacto.ToString(),
                        telefonoContacto = element.telefonoContacto.ToString(),
                        cveTipoEmpleo = element.cveTipoEmpleo.ToString(),
                        descTipoEmpleo = element.tbltiposempleo.descTipoEmpleo.ToString(),
                        cveSubcategoria = element.cveSubcategoria.ToString(),
                        descSubcategoria = element.tblsubcategoria.descSubcategoria.ToString(),
                        cveCategoria = element.tblsubcategoria.cveCategoria.ToString(),
                        descCategoria = element.tblsubcategoria.tblcategoria.descCategoria.ToString(),
                        cveMunicipio = element.cveMunicipio.ToString(),
                        descMunicipio = element.tblmunicipio.descMunicipio.ToString(),
                        cveEstado = element.tblmunicipio.cveEstado.ToString(),
                        descEstado = element.tblmunicipio.tblestado.descEstado.ToString(),

                    });
                }
            
            
            return listaResult;
        }

        public static List<OfertaResult> GetFavoritoById(int idUsuarioExterno)
        {
            //dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tbloferta in dataContext.tblofertas join tblfavoritos in dataContext.tblfavoritos on  tbloferta.idOferta equals tblfavoritos.idOferta
                        join tblmunicipio in dataContext.tblmunicipios on tbloferta.cveMunicipio equals tblmunicipio.cveMunicipio
                        join tblestado in dataContext.tblestados on tblmunicipio.cveEstado equals tblestado.cveEstado
                        join tblsubcategoria in dataContext.tblsubcategorias on tbloferta.cveSubcategoria equals tblsubcategoria.cveSubcategoria
                        join tblcategoria in dataContext.tblcategorias on tblsubcategoria.cveCategoria equals tblcategoria.cveCategoria
                        join tbltiposempleo in dataContext.tbltiposempleos on tbloferta.cveTipoEmpleo equals tbltiposempleo.cveTipoEmpleo
                        join tblempresa in dataContext.tblempresas on tbloferta.cveEmpresa equals tblempresa.cveEmpresa
                        where tblfavoritos.idUsuarioExterno == idUsuarioExterno && tblfavoritos.activo == "S" && tbloferta.fechaFinOferta >= DateTime.Today && tbloferta.activo == "S"
                        select tbloferta ;
            var lista = query.ToList();
            var listaResult = new List<OfertaResult>();
            foreach (tbloferta element in lista)
            {
                var nombreDos = element.tblempresa;
                listaResult.Add(new OfertaResult
                {
                    idOferta = element.idOferta.ToString(),
                    titulo = element.titulo.ToString(),
                    descripcion = element.descripcion.ToString(),
                    sueldoInicio = element.sueldoInicio.ToString(),
                    sueldoFin = element.sueldoFin.ToString(),
                    fechaInicioOferta = element.fechaInicioOferta.ToString(),
                    fechaFinOferta = element.fechaFinOferta.ToString(),
                    cveEmpresa = element.cveEmpresa.ToString(),
                    nombreEmpresa = element.tblempresa.nombre.ToString(),
                    nombreContacto = element.nombreContacto.ToString(),
                    correoContacto = element.correoContacto.ToString(),
                    telefonoContacto = element.telefonoContacto.ToString(),
                    cveTipoEmpleo = element.cveTipoEmpleo.ToString(),
                    descTipoEmpleo = element.tbltiposempleo.descTipoEmpleo.ToString(),
                    cveSubcategoria = element.cveSubcategoria.ToString(),
                    descSubcategoria = element.tblsubcategoria.descSubcategoria.ToString(),
                    cveCategoria = element.tblsubcategoria.cveCategoria.ToString(),
                    descCategoria = element.tblsubcategoria.tblcategoria.descCategoria.ToString(),
                    cveMunicipio = element.cveMunicipio.ToString(),
                    descMunicipio = element.tblmunicipio.descMunicipio.ToString(),
                    cveEstado = element.tblmunicipio.cveEstado.ToString(),
                    descEstado = element.tblmunicipio.tblestado.descEstado.ToString(),

                });
            }
            return listaResult;
        }

        public static List<OfertaResult> GetSugerenciasById(int idUsuarioExterno)
        {
            //dataContext.Configuration.LazyLoadingEnabled = false;
            var query = from tblsubcategoriasusuario in dataContext.tblsubcategoriasusuarios
                        join tblsubcategoria in dataContext.tblsubcategorias on tblsubcategoriasusuario.cveSubcategoria equals tblsubcategoria.cveSubcategoria
                        join tbloferta in dataContext.tblofertas on tblsubcategoria.cveSubcategoria equals tbloferta.cveSubcategoria
                        join tblmunicipio in dataContext.tblmunicipios on tbloferta.cveMunicipio equals tblmunicipio.cveMunicipio
                         join tblestado in dataContext.tblestados on tblmunicipio.cveEstado equals tblestado.cveEstado
                         join tblcategoria in dataContext.tblcategorias on tblsubcategoria.cveCategoria equals tblcategoria.cveCategoria
                         join tbltiposempleo in dataContext.tbltiposempleos on tbloferta.cveTipoEmpleo equals tbltiposempleo.cveTipoEmpleo
                         join tblempresa in dataContext.tblempresas on tbloferta.cveEmpresa equals tblempresa.cveEmpresa
                        where tblsubcategoriasusuario.idUsuarioExterno == idUsuarioExterno && tbloferta.activo == "S" && tbloferta.fechaFinOferta >= DateTime.Today && tblsubcategoria.activo == "S" && tblsubcategoriasusuario.activo=="S"
                        select tbloferta;

            var lista = query.ToList();
            var listaResult = new List<OfertaResult>();
            foreach (tbloferta element in lista)
            {
                var nombreDos = element.tblempresa;
                listaResult.Add(new OfertaResult
                {
                    idOferta = element.idOferta.ToString(),
                    titulo = element.titulo.ToString(),
                    descripcion = element.descripcion.ToString(),
                    sueldoInicio = element.sueldoInicio.ToString(),
                    sueldoFin = element.sueldoFin.ToString(),
                    fechaInicioOferta = element.fechaInicioOferta.ToString(),
                    fechaFinOferta = element.fechaFinOferta.ToString(),
                    cveEmpresa = element.cveEmpresa.ToString(),
                    nombreEmpresa = element.tblempresa.nombre.ToString(),
                    nombreContacto = element.nombreContacto.ToString(),
                    correoContacto = element.correoContacto.ToString(),
                    telefonoContacto = element.telefonoContacto.ToString(),
                    cveTipoEmpleo = element.cveTipoEmpleo.ToString(),
                    descTipoEmpleo = element.tbltiposempleo.descTipoEmpleo.ToString(),
                    cveSubcategoria = element.cveSubcategoria.ToString(),
                    descSubcategoria = element.tblsubcategoria.descSubcategoria.ToString(),
                    cveCategoria = element.tblsubcategoria.cveCategoria.ToString(),
                    descCategoria = element.tblsubcategoria.tblcategoria.descCategoria.ToString(),
                    cveMunicipio = element.cveMunicipio.ToString(),
                    descMunicipio = element.tblmunicipio.descMunicipio.ToString(),
                    cveEstado = element.tblmunicipio.cveEstado.ToString(),
                    descEstado = element.tblmunicipio.tblestado.descEstado.ToString(),

                });
            }
            return listaResult;
        }

        public static List<tblaspirante> GetDatosGeneralesById(int idUsuarioExterno)
        {
            var query = from tblaspirante in dataContext.tblaspirantes
                        where tblaspirante.idUsuarioExterno == idUsuarioExterno && tblaspirante.activo == "S" 
                        select tblaspirante;
            return query.ToList();
        }


        //select * from tblsubcategoriasusuarios subc join tblsubcategorias sub on (subc.cveSubcategoria=sub.cveSubcategoria) join tblofertas ofe on (ofe.cveSubcategoria=sub.cveSubcategoria);
    }
}
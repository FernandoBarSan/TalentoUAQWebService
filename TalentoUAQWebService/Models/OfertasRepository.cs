using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TalentoUAQWebService.Models
{
    public class OfertasRepository
    {
        private static TalentoUAQEntities dataContext = new TalentoUAQEntities();

        public static List<OfertaResult> BusquedaOfertas(string titulo,
            string sueldoInicio, string sueldoFin, string fechaInicioOferta,
            string fechaFinOferta, string cveEmpresa, string cveTipoEmpleo,
            string cveSubcategoria, string cveCategoria, string cveMunicipio, string cveEstado)
        {
            //dataContext.Configuration.LazyLoadingEnabled = false;
            //dataContext.Configuration.AutoDetectChangesEnabled = false;
            DateTime inicio = new DateTime();
            if (fechaInicioOferta != "0") { 
                string[] SeparateInicio = fechaInicioOferta.Split('-');

                int diaSelectInicio = Int32.Parse(SeparateInicio[0]);
                int mesSelectInicio = Int32.Parse(SeparateInicio[1]);
                int anioSelectInicio = Int32.Parse(SeparateInicio[2]);

                inicio = new DateTime(anioSelectInicio, mesSelectInicio, diaSelectInicio, 0, 0, 0, 0);
            }
            var query = (from tbloferta in dataContext.tblofertas
                         join tblmunicipio in dataContext.tblmunicipios on tbloferta.cveMunicipio equals tblmunicipio.cveMunicipio
                         join tblestado in dataContext.tblestados on tblmunicipio.cveEstado equals tblestado.cveEstado
                         join tblsubcategoria in dataContext.tblsubcategorias on tbloferta.cveSubcategoria equals tblsubcategoria.cveSubcategoria
                         join tblcategoria in dataContext.tblcategorias on tblsubcategoria.cveCategoria equals tblcategoria.cveCategoria
                         join tbltiposempleo in dataContext.tbltiposempleos on tbloferta.cveTipoEmpleo equals tbltiposempleo.cveTipoEmpleo
                         join tblempresa in dataContext.tblempresas on tbloferta.cveEmpresa equals tblempresa.cveEmpresa
                         select tbloferta);
            query= query.Where(a => a.activo  == "S");
            query = query.Where(a => a.tblmunicipio.activo == "S");
            query = query.Where(a => a.tblmunicipio.tblestado.activo == "S");
            if (fechaInicioOferta != "0")
            {
                query = query.Where(a => a.fechaInicioOferta >= inicio);
            }
            if (titulo != "0") {
                query = query.Where(a => a.titulo.Contains(titulo));
            }
            if (sueldoInicio != "0")
            {
                var cvesueldoInicioInt = int.Parse(sueldoInicio);
                query = query.Where(a => a.sueldoInicio >= cvesueldoInicioInt);
            }
            if (sueldoFin != "0")
            {
                var sueldoFinInt = int.Parse(sueldoFin);
                query = query.Where(a => a.sueldoFin <= sueldoFinInt);
            }
            if (cveEmpresa != "0")
            {
                var cveEmpresaInt = int.Parse(cveEmpresa);
                query = query.Where(a => a.cveEmpresa == cveEmpresaInt);
            }
            if (cveTipoEmpleo != "0")
            {
                var cveTipoEmpleoInt = int.Parse(cveTipoEmpleo);
                query = query.Where(a => a.cveTipoEmpleo == cveTipoEmpleoInt);
            }
            if (cveSubcategoria != "0")
            {
                var cveSubcategoriaInt = int.Parse(cveSubcategoria);
                query = query.Where(a => a.cveSubcategoria == cveSubcategoriaInt);
            }
            if (cveCategoria != "0")
            {
                var cveCategoriaInt = int.Parse(cveCategoria);
                query = query.Where(a => a.tblsubcategoria.cveCategoria == cveCategoriaInt);
            }
            if (cveMunicipio != "0")
            {
                var cveMunicipioInt = int.Parse(cveMunicipio);
                query = query.Where(a => a.cveMunicipio == cveMunicipioInt);
            }
            if (cveEstado != "0")
            {
                var cveEstadoInt = int.Parse(cveEstado);
                query = query.Where(a => a.tblmunicipio.tblestado.cveEstado == cveEstadoInt);
            }
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
                    correoContacto = element.nombreContacto.ToString(),
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

        internal static object GetAllOfertas()
        {
            throw new NotImplementedException();
        }

        internal static object GetOferta(int id)
        {
            throw new NotImplementedException();
        }

        internal static object SearchOfertasByName(string name)
        {
            throw new NotImplementedException();
        }

    }

    public class OfertaResult
    {
        public string idOferta { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string sueldoInicio { get; set; }
        public string sueldoFin { get; set; }
        public string fechaInicioOferta { get; set; }
        public string fechaFinOferta { get; set; }
        public string cveEmpresa { get; set; }
        public string nombreEmpresa { get; set; }
        public string nombreContacto { get; set; }
        public string correoContacto { get; set; }
        public string telefonoContacto { get; set; }
        public string cveTipoEmpleo { get; set; }
        public string descTipoEmpleo { get; set; }
        public string cveSubcategoria { get; set; }
        public string descSubcategoria { get; set; }
        public string cveCategoria { get; set; }
        public string descCategoria { get; set; }
        public string cveMunicipio { get; set; }
        public string descMunicipio { get; set; }
        public string cveEstado { get; set; }
        public string descEstado { get; set; }

    }
}
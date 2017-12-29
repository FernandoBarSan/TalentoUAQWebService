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

        public static List<tbloferta> BusquedaOfertas(string titulo,
            string sueldoInicio, string sueldoFin, string fechaInicioOferta,
            string fechaFinOferta, string cveEmpresa, string cveTipoEmpleo,
            string cveSubcategoria, string cveMunicipio)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
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
                         select tbloferta);
            query= query.Where(a => a.activo  == "S");
            if (fechaInicioOferta != "0")
            {
                query = query.Where(a => a.fechaInicioOferta >= inicio);
            }
            if (titulo != "0") {
                query = query.Where(a => a.titulo.Contains(titulo));
            }
            if (sueldoInicio != "0")
            {
                query = query.Where(a => a.sueldoInicio >= Int32.Parse(sueldoInicio));
            }
            if (sueldoFin != "0")
            {
                query = query.Where(a => a.sueldoFin <= Int32.Parse(sueldoFin));
            }
            if (cveEmpresa != "0")
            {
                query = query.Where(a => a.cveEmpresa == Int32.Parse(cveEmpresa));
            }
            if (cveTipoEmpleo != "0")
            {
                query = query.Where(a => a.cveTipoEmpleo == Int32.Parse(cveTipoEmpleo));
            }
            if (cveSubcategoria != "0")
            {
                query = query.Where(a => a.cveSubcategoria == Int32.Parse(cveSubcategoria));
            }
            if (cveMunicipio != "0")
            {
                query = query.Where(a => a.cveMunicipio == Int32.Parse(cveMunicipio));
            }
            return query.ToList();
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
}
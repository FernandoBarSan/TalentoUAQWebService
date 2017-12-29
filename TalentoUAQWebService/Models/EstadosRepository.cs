using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentoUAQWebService.Models
{
    public class EstadosRepository
    {
        private static TalentoUAQEntities dataContext = new TalentoUAQEntities();

        public static List<tblestado> GetAllEstados()
        {

            dataContext.Configuration.LazyLoadingEnabled = false;
            //dataContext.Configuration.AutoDetectChangesEnabled = false;
            var query = (from tblestado in dataContext.tblestados
                         where tblestado.activo.Contains("S")
                         select tblestado);
            return query.ToList();
        }
        public static List<tblestado> SearchEstadosByName(string tblestadoName)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            //dataContext.Configuration.AutoDetectChangesEnabled = false;
            var query = from tblestado in dataContext.tblestados
                        where (tblestado.descEstado.Contains(tblestadoName) &&
                        tblestado.activo.Contains("S"))
                        select tblestado;
            return query.ToList();
        }
        public static tblestado GetEstado(int EstadoID)
        {
            dataContext.Configuration.LazyLoadingEnabled = false;
            //dataContext.Configuration.AutoDetectChangesEnabled = false;
            var query = from tblestado in dataContext.tblestados
                        where tblestado.cveEstado == EstadoID
                        select tblestado;
            return query.SingleOrDefault();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TalentoUAQWebService.Models;

namespace TalentoUAQWebService.Controllers
{
    [EnableCors(origins: "http://localhost:55058", headers: "*", methods: "*")]
    public class OfertasController : ApiController
    {
        // GET: api/Ofertas
        [Route("api/tblofertas")]
        public HttpResponseMessage Get()
        {
            var tblofertas = OfertasRepository.GetAllOfertas();
            Console.Write(tblofertas.ToString());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblofertas);
            return response;
        }

        // GET: api/Ofertas/5
        [Route("api/tblofertas/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var tblofertas = OfertasRepository.GetOferta(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblofertas);
            return response;
        }

        [Route("api/tblofertas/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var tblofertas = OfertasRepository.SearchOfertasByName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblofertas);
            return response;
        }
        // GET: api/tblofertasbusqueda/titulo/0/sueldoInicio/0/sueldoFin/0/fechaInicioOferta/0/fechaFinOferta/0/cveEmpresa/0/cveTipoEmpleo/0/cveSubcategoria/0/cveMunicipio/0/
        [Route("api/tblofertasbusqueda/titulo/{titulo:regex([a-zA-Z_0-9]*)}/sueldoInicio/{sueldoInicio?}/sueldoFin/{sueldoFin?}/fechaInicioOferta/{fechaInicioOferta?}/fechaFinOferta/{fechaFinOferta?}/cveEmpresa/{cveEmpresa?}/cveTipoEmpleo/{cveTipoEmpleo?}/cveSubcategoria/{cveSubcategoria?}/cveMunicipio/{cveMunicipio?}/")]
        public HttpResponseMessage Get(string titulo, 
            string sueldoInicio, string sueldoFin, string fechaInicioOferta,
            string fechaFinOferta, string cveEmpresa, string cveTipoEmpleo, 
            string cveSubcategoria, string cveMunicipio)
        {            
            var tblofertas = OfertasRepository.BusquedaOfertas(titulo, sueldoInicio,
                sueldoFin, fechaInicioOferta, fechaFinOferta, cveEmpresa, cveTipoEmpleo,
                cveSubcategoria, cveMunicipio);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblofertas);
            return response;
        }

        // POST: api/Ofertas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Ofertas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ofertas/5
        public void Delete(int id)
        {
        }
    }
}
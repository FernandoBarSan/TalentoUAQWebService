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
    public class tblmunicipiosController : ApiController
    {
        // GET: api/tblmunicipios
        [Route("api/tblmunicipios")]
        public HttpResponseMessage Get()
        {
            var subcategorias = TalentoRepository.GetMunicipio();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, subcategorias);
            return response;
        }

        // GET: api/tblmunicipios/5
        [Route("api/tblmunicipios/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var municipio = TalentoRepository.GetEstadoById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, municipio);
            return response;
        }

        // GET: api/tblmunicipios/estado/5
        [Route("api/tblmunicipios/estado/{idCategoria?}")]
        public HttpResponseMessage GetMunicipio(int cveEstado)
        {
            var municipio = TalentoRepository.GetMunicipioByIdEstado(cveEstado);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, municipio);
            return response;
        }

        // POST: api/tblmunicipios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/tblmunicipios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/tblmunicipios/5
        public void Delete(int id)
        {
        }
    }
}

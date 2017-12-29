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
    public class tblestadosController : ApiController
    {
        // GET: api/tblestados
        [Route("api/tblestados")]
        public HttpResponseMessage Get()
        {
            var subcategorias = TalentoRepository.GetEstado();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, subcategorias);
            return response;
        }

        // GET: api/tblestados/5
        [Route("api/tblestados/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var subcategoria = TalentoRepository.GetEstadoById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, subcategoria);
            return response;
        }
         
        // POST: api/tblestados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/tblestados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/tblestados/5
        public void Delete(int id)
        {
        }
    }
}

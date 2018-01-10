using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TalentoUAQWebService.Models;

namespace TalentoUAQWebService.Controllers
{
    public class tblExperienciasController : ApiController
    {
        // GET: api/tblExperiencias
        [Route("api/tblExperiencias/")]
        public HttpResponseMessage Get()
        {
            var tblExperiencias = TalentoRepository.GetExperiencias();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblExperiencias);
            return response;
        }

        // GET: api/tblExperiencias/5
        [Route("api/tblExperiencias/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var tblExperiencias = TalentoRepository.GetExperienciaById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblExperiencias);
            return response;
        }

        // POST: api/tblExperiencias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/tblExperiencias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/tblExperiencias/5
        public void Delete(int id)
        {
        }
    }
}

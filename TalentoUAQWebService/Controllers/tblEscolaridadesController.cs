using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TalentoUAQWebService.Models;

namespace TalentoUAQWebService.Controllers
{
    public class tblEscolaridadesController : ApiController
    {
        // GET: api/tblEscolaridades
        [Route("api/tblEscolaridades/")]
        public HttpResponseMessage Get()
        {
            var tblEscolaridades = TalentoRepository.GetEscolaridad();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblEscolaridades);
            return response;
        }

        // GET: api/tblEscolaridades/5
        [Route("api/tblEscolaridades/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var tblEscolaridades = TalentoRepository.GetEscolaridadById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblEscolaridades);
            return response;
        }

        // POST: api/tblEscolaridades
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/tblEscolaridades/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/tblEscolaridades/5
        public void Delete(int id)
        {
        }
    }
}

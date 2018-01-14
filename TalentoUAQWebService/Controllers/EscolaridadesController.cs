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
    public class EscolaridadesController : ApiController
    {

        // POST: api/escolaridades/guardar
        [Route("api/escolaridades/guardar")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]tblescolaridade value)
        {
            var tblescolaridades = EscolaridadesRepository.guardarEscolaridades(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblescolaridades);
            return response;
        }

        // PUT: api/Escolaridades/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Escolaridades/5
        public void Delete(int id)
        {
        }
    }
}

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
    public class AspirantesController : ApiController
    {
        // POST: api/aspirantes/guardar
        [Route("api/aspirantes/guardar")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]tblaspirante value)
        {
            var tblaspirante = AspiranteRepository.guardarAspirante(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblaspirante);
            return response;
        }

        // PUT: api/Aspirantes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Aspirantes/5
        public void Delete(int id)
        {
        }
    }
}

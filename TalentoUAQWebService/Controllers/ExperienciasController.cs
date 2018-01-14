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
    public class ExperienciasController : ApiController
    {

        // POST: api/experiencias/guardar
        [Route("api/experiencias/guardar")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]tblexperiencia value)
        {
            var tblexperiencias = ExperienciasRepository.guardarExperiencia(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblexperiencias);
            return response;
        }

        // PUT: api/Experiencias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Experiencias/5
        public void Delete(int id)
        {
        }
    }
}

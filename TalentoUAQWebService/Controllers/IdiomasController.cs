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
    public class IdiomasController : ApiController
    {

        // POST: api/idiomas/guardar
        [Route("api/idiomas/guardar")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]tblidioma value)
        {
            var tblidioma = IdiomasRepository.guardarIdioma(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblidioma);
            return response;
        }

        // PUT: api/Idiomas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Idiomas/5
        public void Delete(int id)
        {
        }
    }
}

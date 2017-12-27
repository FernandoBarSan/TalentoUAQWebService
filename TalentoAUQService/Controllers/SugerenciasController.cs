using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TalentoAUQService.Models;

namespace TalentoAUQService.Controllers
{
    public class SugerenciasController : ApiController
    {
        // GET: api/Sugerencias
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sugerencias/5
        [Route("api/sugerencias/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var tblsugerencias = TalentoRepository.GetSugerenciasById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblsugerencias);
            return response;
        }

        // POST: api/Sugerencias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sugerencias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sugerencias/5
        public void Delete(int id)
        {
        }
    }
}

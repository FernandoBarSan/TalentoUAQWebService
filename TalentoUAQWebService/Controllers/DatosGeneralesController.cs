using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TalentoUAQWebService.Models;

namespace TalentoUAQWebService.Controllers
{
    public class DatosGeneralesController : ApiController
    {
        // GET: api/DatosGenerales
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DatosGenerales/5
        [Route("api/DatosGenerales/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var tblfavoritos = TalentoRepository.GetDatosGeneralesById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblfavoritos);
            return response;
        }

        // POST: api/DatosGenerales
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DatosGenerales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DatosGenerales/5
        public void Delete(int id)
        {
        }
    }
}

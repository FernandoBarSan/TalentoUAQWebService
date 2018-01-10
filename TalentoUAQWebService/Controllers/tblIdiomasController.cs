using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TalentoUAQWebService.Models;

namespace TalentoUAQWebService.Controllers
{
    public class tblIdiomasController : ApiController
    {
        // GET: api/tblIdiomas
        [Route("api/tblIdiomas/")]
        public HttpResponseMessage Get()
        {
            var subcategorias = TalentoRepository.GetIdiomas();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, subcategorias);
            return response;
        }

        // GET: api/tblIdiomas/5
        [Route("api/tblIdiomas/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var tblfavoritos = TalentoRepository.GetIdiomaById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblfavoritos);
            return response;
        }

        // POST: api/tblIdiomas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/tblIdiomas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/tblIdiomas/5
        public void Delete(int id)
        {
        }
    }
}

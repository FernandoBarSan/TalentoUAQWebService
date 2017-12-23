using TalentoAUQService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TalentoAUQService.Controllers
{
    public class EstadosController : ApiController
    {
        [EnableCors(origins: "http://localhost:55058", headers: "*", methods: "*")]
        public class CategoriasController : ApiController
        {
            // GET: api/Estados
            [Route("api/tblestados")]
            public HttpResponseMessage Get()
            {
                var tblestados = EstadosRepository.GetAllEstados();
                Console.Write(tblestados.ToString());
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblestados);
                return response;
            }

            // GET: api/Estados/5
            [Route("api/tblestatos/{id?}")]
            public HttpResponseMessage Get(int id)
            {
                var tblestados = EstadosRepository.GetEstado(id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblestados);
                return response;
            }

            [Route("api/tblestados/{name:alpha}")]
            public HttpResponseMessage Get(string name)
            {
                var tblestados = EstadosRepository.SearchEstadosByName(name);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblestados);
                return response;
            }

            // POST: api/Estados
            public void Post([FromBody]string value)
            {
            }

            // PUT: api/Estados/5
            public void Put(int id, [FromBody]string value)
            {
            }

            // DELETE: api/Estados/5
            public void Delete(int id)
            {
            }
        }
    }
}

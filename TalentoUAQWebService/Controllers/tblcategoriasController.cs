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
    public class tblcategoriasController : ApiController
    {
        // GET: api/tblcategorias
        [Route("api/tblcategorias")]
        public HttpResponseMessage Get()
        {
            var categorias = TalentoRepository.GetCategorias();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, categorias);
            return response;
        }

        // GET: api/tblcategorias/5
        [Route("api/tblcategorias/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var categoria = TalentoRepository.GetCategoriaById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, categoria);
            return response;
        }

        // POST: api/tblcategorias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/tblcategorias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/tblcategorias/5
        public void Delete(int id)
        {
        }
    }
}

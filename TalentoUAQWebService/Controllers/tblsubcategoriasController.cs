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
    public class tblsubcategoriasController : ApiController
    {
        // GET: api/tblsubcategorias
        [Route("api/tblsubcategorias")]
        public HttpResponseMessage Get()
        {
            var subcategorias = TalentoRepository.GetSubcategoria();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, subcategorias);
            return response;
        }

        // GET: api/tblsubcategorias/5
        [Route("api/tblsubcategorias/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var subcategoria = TalentoRepository.GetSubcategoriaById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, subcategoria);
            return response;
        }

        // GET: api/tblsubcategorias/categoria/5
        [Route("api/tblsubcategorias/categoria/{id?}")]
        public HttpResponseMessage GetCategoria(int cveCategoria)
        {
            var subicategoria = TalentoRepository.GetSubcategoriaByCategoria(cveCategoria);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, subicategoria);
            return response;
        }

        // POST: api/tblsubcategorias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/tblsubcategorias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/tblsubcategorias/5
        public void Delete(int id)
        {
        }
    }
}

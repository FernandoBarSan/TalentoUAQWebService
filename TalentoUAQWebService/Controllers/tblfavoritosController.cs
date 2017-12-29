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
    public class tblfavoritosController : ApiController
    {
        // GET: api/tblfavoritos
        [Route("api/tblfavoritos/")]
        public HttpResponseMessage Get()
        {
                var tblfavoritos = TalentoRepository.GetFavorito();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblfavoritos);
            return response;
        }

        // GET: api/tblfavoritos/5
        [Route("api/tblfavoritos/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var tblfavoritos = TalentoRepository.GetFavoritoById(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblfavoritos);
            return response;
        }

        // POST: api/tblfavoritos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/tblfavoritos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/tblfavoritos/5
        public void Delete(int id)
        {
        }
    }
}

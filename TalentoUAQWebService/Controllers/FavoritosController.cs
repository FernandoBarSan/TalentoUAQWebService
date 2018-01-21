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
    public class FavoritosController : ApiController
    {
        // POST: api/favoritos/guardar
        [Route("api/favoritos/guardar")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]tblfavorito value)
        {
            var tblfavorito = FavoritosRepository.GuardarFavorito(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblfavorito);
            return response;
        }
        

        // PUT: api/Favoritos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Favoritos/5
        public void Delete(int id)
        {
        }
    }
}

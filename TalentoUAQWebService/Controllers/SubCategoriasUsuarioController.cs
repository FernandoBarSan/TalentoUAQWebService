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
    public class SubCategoriasUsuarioController : ApiController
    {


        // POST: api/subcategoriasusuario/guardar
        [Route("api/subcategoriasusuario/guardar")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]tblsubcategoriasusuario value)
        {
            var tblsubcategoriasusuario = SubCategoriasUsuarioRepository.GuardarSubCategoriaUsuario(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, tblsubcategoriasusuario);
            return response;
        }

        // PUT: api/SubCategoriasUsuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SubCategoriasUsuario/5
        public void Delete(int id)
        {
        }
    }
}

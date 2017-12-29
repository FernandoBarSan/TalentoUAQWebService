using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentoUAQWebService.Models
{
    public class favoritosClass
    {
        public List<tblfavorito> favorito { get; set; }
        public List<tblsubcategoria> subcategoria { get; set; }
        public List<tblcategoria> categoria { get; set; }
        public List<tbloferta> oferta { get; set; }
    }
}
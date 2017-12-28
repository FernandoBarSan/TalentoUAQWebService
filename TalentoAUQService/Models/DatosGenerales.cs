using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentoAUQService.Models
{
    public class DatosGenerales
    {
        
        public List<tblsubcategoria> subcategorias { get; set; }
        public List<tblescolaridade> escoladirades { get; set; }
        public List<tblexperiencia> experiencias { get; set; }
        public List<tblidioma> idiomas { get; set; }
        public List<tblaspirante> aspirante { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TalentoAUQService
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblsubcategoriasusuario
    {
        public int idSubcategoriaUsuario { get; set; }
        public Nullable<int> cveSubcategoria { get; set; }
        public Nullable<int> idUsuarioExterno { get; set; }
        public string activo { get; set; }
        public Nullable<System.DateTime> fechaRegistro { get; set; }
        public Nullable<System.DateTime> fechaActualizacion { get; set; }
    
        public virtual tblsubcategoria tblsubcategoria { get; set; }
    }
}

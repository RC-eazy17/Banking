using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos;
using Presentacion.Models;

namespace Presentacion.Models.Filter
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class AuthorizerUsuario : AuthorizeAttribute
    {
        
        private Usuario user;
        private PFinalEntities db = new PFinalEntities();
        private int idOperacion;

        public AuthorizerUsuario(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOp = "";
            String nombreMod = "";

            try
            {
                user = (Usuario)HttpContext.Current.Session["User"];
                var lstOP = from m in db.RolOperacions
                            where m.IdRol == user.IdRol
                            && m.IdOperacion == idOperacion
                            select m;
                if (lstOP.ToList().Count() < 1)
                {
                    var oOperacion = db.Operaciones.Find(idOperacion);
                    int? idModulo = oOperacion.IdModulo;
                    nombreOp = getNombreOp(idOperacion);
                    nombreMod = getNombreMod(idModulo);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOp + "&modulo=" + nombreMod + "&msjeErrorExcepcion=");
                }
            }
            
            catch (Exception ex)
            {

                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOp + "&modulo=" + nombreMod + "&msjeErrorExcepcion=" + ex.Message);
            }

            
        }

        public string getNombreOp(int idOp)
        {
            var ope = from op in db.Operaciones
                      where op.Id == idOp
                      select op.Nombre;
            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }

        public string getNombreMod(int? idMod)
        {
            var modulo = from m in db.Moduloes
                         where m.Id == idMod
                         select m.Nombre;
            String nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }
    }  
    
}
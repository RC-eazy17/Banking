using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentacion.Models;
using Presentacion.Controllers;
using Entidades;

namespace Presentacion.Models.Filter
{
    public class VerificarSession : ActionFilterAttribute
    {
        private Usuario usuario;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                base.OnActionExecuted(filterContext);

                usuario = (Usuario)HttpContext.Current.Session["User"];

                if (usuario == null)
                {
                    if (filterContext.Controller is AccountController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Account/LogIn");

                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Account/LogIn");

                
            }

            

            
        }

    }
}
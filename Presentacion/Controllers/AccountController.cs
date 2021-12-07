using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Datos;
using Negocio;

namespace Presentacion.Controllers
{
    public class AccountController : Controller
    {
        
            
        UsuarioNegocio negocio = new UsuarioNegocio();
        PFinalEntities db = new PFinalEntities();

        public ActionResult Index() 
        {
            return View();
        }


       
        // GET: Account
        [HttpGet]
        public ActionResult Signup()
        {
            negocio.GetDatos();

            var data = negocio.Listar();


            List<SelectListItem> items = data.ConvertAll(e =>
            {
                return new SelectListItem()
                {
                    Text = e.Nombre.ToString(),
                    Value = e.Id.ToString(),
                    Selected = false
                };

            });

            ViewBag.items = items;

            return View();
        }

        [HttpPost]
        public ActionResult Signup(Usuario usuario)
        {
            usuario.IdEstado = 1;
            usuario.IdRol = 2;

            negocio.Signup(usuario);

            Session["Id"] = usuario.Id.ToString();
            Session["Nombre"] = usuario.Nombre.ToString();


            return RedirectToAction("../Cliente/IndexPrincipal");
        }

        public ActionResult Logout(Usuario usuario)
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Usuario usurio, string user, string contra)
        {
            contra = usurio.Contraseña;
            user =usurio.Email;

            try
            {
                using (PFinalEntities db = new PFinalEntities())
                {
                    var lst = from d in db.Usuarios
                                where d.Email == user && d.Contraseña == contra && d.IdEstado == 1
                                select d;
                    if (lst.Count()>0) 
                    {
                        Usuario usuario1 = lst.First();
                        Session["User"] = usuario1;
                        Session["Id"] = usurio.Id.ToString();
                        Session["Nombre"] = usurio.Email.ToString();

                        ViewBag.Error = "Usuario o contraseña invalidad";

                        return RedirectToAction("../Cliente/IndexPrincipal");

                        

                        //return Content("1");
                        

                    }
                    else
                    {
                        return Content("Invalido");
                    }

                }
                
            }
            catch (Exception ex)
            {
                return Content("Error" + ex.Message);
                
            }


            
        }


    }
}
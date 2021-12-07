using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;
using Presentacion.Models;
using Presentacion.Models.Filter;

namespace Presentacion.Controllers
{
    public class AdminController : Controller
    {
        UsuarioNegocio negocio = new UsuarioNegocio();

        // GET: Admin
        public ActionResult Index() 
        {
            return View();
        }

        #region Cliente
        
        [AuthorizerUsuario(idOperacion:1)]
        public ActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCliente(Cliente cliente)
        {
            negocio.Insertar(cliente);
            return View(cliente);
        }

        [AuthorizerUsuario(idOperacion: 2)]
        public ActionResult ListadoCliente(Cliente cliente)
        {
            var c = negocio.Listar();
            return View(c);
        }

        [AuthorizerUsuario(idOperacion: 3)]
        public ActionResult Editar(int id)
        {

            //negocio.GetCliente(id);


            return View();
        }

        

        [HttpPost]
        public ActionResult Editar(Cliente cliente, int id)
        {

            negocio.Editar(cliente, id);

            return Redirect("~/Admin/ListadoCliente");
        }

        [AuthorizerUsuario(idOperacion: 4)]
        [HttpGet]
        public ActionResult Eliminar(int id)
        {

            negocio.Eliminar(id);

            return Redirect("~/Admin/ListadoCliente");


        }
        #endregion

        #region CUENTA

        [AuthorizerUsuario(idOperacion: 5)]
        public ActionResult CrearCuenta(Cliente cliente)
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
        public ActionResult CrearCuenta(Cuenta cuenta)
        {
            cuenta.FechaCreacion = DateTime.Now;
            

            negocio.Insertar(cuenta);

            return RedirectToAction("ListarCuentas");
        }

        [AuthorizerUsuario(idOperacion: 6)]
        public ActionResult ListarCuentas(Cuenta cuenta)
        {
            var data = negocio.Listar2();



            return View(data);
        }

        public ActionResult EditarCuenta(int id)
        {

            //using (var c = new PFinalEntities())
            //{
            //    var data = c.Estudiantes.Where(a => a.id == id).SingleOrDefault();


            return View();

            //}
        }

        [AuthorizerUsuario(idOperacion: 7)]
        [HttpPost]
        public ActionResult EditarCuenta(Cuenta cuenta, int id)
        {

            negocio.Editar2(cuenta, id);
            return Redirect("ListarCuentas");
        }


        [AuthorizerUsuario(idOperacion: 8)]
        [HttpGet]
        public ActionResult EliminarCuentas(int id)
        {

            negocio.Eliminar2(id);

            return Redirect("~/Admin/ListarCuentas/");


        }



        #endregion

        #region PRESTAMO

        [AuthorizerUsuario(idOperacion: 9)]
        public ActionResult CrearPrestamo()
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
        public ActionResult CrearPrestamo(Prestamo prestamo)
        {
            prestamo.FechaCreacion = DateTime.Now;

            negocio.Insertar(prestamo);

            return RedirectToAction("ListarPrestamo");
        }

        [AuthorizerUsuario(idOperacion: 10)]
        public ActionResult ListarPrestamo(Prestamo prestamo)
        {
            var data = negocio.Listar3();

            return View(data);
        }

        public ActionResult EditarPrestamo(int id)
        {

            //using (var c = new PFinalEntities())
            //{
            //    var data = c.Estudiantes.Where(a => a.id == id).SingleOrDefault();


            return View();

            //}
        }

        [AuthorizerUsuario(idOperacion: 11)]
        [HttpPost]
        public ActionResult EditarPrestamo(Prestamo prestamo, int id)
        {

            negocio.Editar3(prestamo, id);

            return Redirect("~/Admin/ListarPrestamo/");
        }

        [AuthorizerUsuario(idOperacion: 12)]
        [HttpGet]
        public ActionResult EliminarPrestamo(int id)
        {

            negocio.Eliminar3(id);

            return Redirect("~/Admin/ListarPrestamo/");


        }


        #endregion

        #region TARJETA

        [AuthorizerUsuario(idOperacion: 13)]
        public ActionResult CrearTarjeta()
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
        public ActionResult CrearTarjeta(TarjetaCredito tarjeta)
        {
            tarjeta.FechaCreacion = DateTime.Now;
            negocio.Insertar(tarjeta);

            return RedirectToAction("ListarTarjeta");
        }

        [AuthorizerUsuario(idOperacion: 14)]
        public ActionResult ListarTarjeta(TarjetaCredito tarjeta)
        {
            var data = negocio.Listar4();

            return View(data);
        }

        [AuthorizerUsuario(idOperacion: 15)]
        public ActionResult EditarTarjetas(int id)
        {

            //using (var c = new PFinalEntities())
            //{
            //    var data = c.Estudiantes.Where(a => a.id == id).SingleOrDefault();


            return View();

            //}
        }


        [HttpPost]
        public ActionResult EditarTarjetas(TarjetaCredito tarjeta, int id)
        {

            negocio.Editar4(tarjeta, id);

            

            return Redirect("~/Admin/ListarTarjeta/");
        }

        [AuthorizerUsuario(idOperacion: 16)]
        [HttpGet]
        public ActionResult EliminarTarjeta(int id)
        {

            negocio.Eliminar4(id);

            return Redirect("~/Admin/ListarTarjeta/");


        }
        #endregion

    }
  
}

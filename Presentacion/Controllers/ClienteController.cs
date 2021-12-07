using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entidades;
using Datos;
using System.Web.UI.WebControls;
using Presentacion.Models;
using Presentacion.Models.Filter;

namespace Presentacion.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente

        UsuarioNegocio negocio = new UsuarioNegocio();


        public ActionResult IndexPrincipal() 
        {
            return View();
        }

        public ActionResult IndexBalance()
        {
            return View();
        }
        public ActionResult IndexTrans()
        {
            return View();
        }



        #region BALANCE

        [AuthorizerUsuario(idOperacion: 17)]
        public ActionResult BalanceCuenta()
        {
            var c = negocio.Listar2();
            return View(c);

            
        }

        [AuthorizerUsuario(idOperacion: 17)]
        public ActionResult BalancePrestamo()
        {
            
            return View();


        }
        [AuthorizerUsuario(idOperacion: 17)]
        public ActionResult BalanceTajeta()
        {

            return View();


        }


        #endregion

        #region TRANS

        [AuthorizerUsuario(idOperacion: 20)]
        public ActionResult Transferencia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Transferencia(Cuenta cuenta)
        {
            return View();
        }

        [AuthorizerUsuario(idOperacion: 18)]
        public ActionResult Depositar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Depositar(Model model,Nullable<int> idC, Nullable<int> numC, Nullable<decimal> cant, Nullable<System.DateTime> fechaR, string accion)
        {
            idC = model.Id;
            cant = model.Cantidad ;
            numC = model.NumC;
            fechaR = DateTime.Today;
            accion = "DEPOSITO";


            negocio.SP_Deposito(idC, numC, cant, fechaR, accion);
            
            return View();
        }

        [AuthorizerUsuario(idOperacion: 19)]
        public ActionResult Retirar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Retirar(Model model, Nullable<int> idC, Nullable<int> numC, Nullable<decimal> cant, Nullable<System.DateTime> fechaR, string accion)
        {
            idC = model.Id;
            cant = model.Cantidad;
            numC = model.NumC;
            fechaR = DateTime.Today;
            accion = "RETIRO";


            negocio.SP_Retiro(idC, numC, cant, fechaR, accion);

            return View();
        }

        [AuthorizerUsuario(idOperacion: 17)]
        public ActionResult BuscarRD()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult BuscarRD(Model model, string accion, string numC, Nullable<System.DateTime> fECHA1, Nullable<System.DateTime> fECHA2)
        {
            accion = model.Accion;
            numC = model.NumC1;
            fECHA1 = model.F1;
            fECHA2 = model.F2;


            negocio.SP_BucarRD(accion, numC, fECHA1, fECHA2);
            return View();
        }

        
        #endregion


    }
}
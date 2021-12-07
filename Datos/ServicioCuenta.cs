using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using Entidades;
using Microsoft.Data.OData.Query.SemanticAst;
using SelectListItem = System.Web.WebPages.Html.SelectListItem;

namespace Datos
{
    public class ServicioCuenta
    {
        PFinalEntities db = new PFinalEntities();

        public void Insertar(Cuenta cuenta)
        {
            db.Cuentas.Add(cuenta);
            db.SaveChanges();
        }

        public List<Cuenta> Listar2()
        {
            return db.Cuentas.ToList();
        }

        public void Editar2(Cuenta c, int id)
        {
            using (var db = new PFinalEntities())
            {
                var data = db.Cuentas.Where(a => a.Id == id).SingleOrDefault();

                if (data != null)
                {
                    data.NumCuenta = c.NumCuenta;
                    data.Balance = c.Balance;
                    //data.Monto = c.Monto;
                    data.FechaCreacion = c.FechaCreacion;
                    data.IdCliente  = c.IdCliente;
                    

                    db.SaveChanges();


                }

            }
        }

        public void Eliminar2(int id)
        {
            using (PFinalEntities d = new PFinalEntities())
            {
                var user = d.Cuentas.Find(id);
                d.Cuentas.Remove(user);
                d.SaveChanges();

            }
        }


        public List<Cliente> getDatos()
        {
            return db.Clientes.ToList();
            
        }

        public void SP_Deposito(Nullable<int> idC, Nullable<int> numC, Nullable<decimal> cantidad, Nullable<System.DateTime> fechaR, string accion)
        {
            using (PFinalEntities db = new PFinalEntities())
            {
                db.SP_Deposito(idC, numC, cantidad, fechaR, accion);
                db.SaveChanges();

            }

            
        }

        public void SP_Retiro(Nullable<int> idC, Nullable<int> numC, Nullable<decimal> cantidad, Nullable<System.DateTime> fechaR, string accion)
        {
            using (PFinalEntities db = new PFinalEntities())
            {
                db.SP_Retiro(idC, numC, cantidad, fechaR, accion);
                db.SaveChanges();

            }


        }

        public void SP_BucarRD(string accion, string numC, Nullable<System.DateTime> fECHA1, Nullable<System.DateTime> fECHA2)
        {
            using (PFinalEntities db = new PFinalEntities())
            {
                db.SP_BucarRD(accion, numC,fECHA1,fECHA2).ToList();
                db.SaveChanges();

            }
            
        }


    }
}

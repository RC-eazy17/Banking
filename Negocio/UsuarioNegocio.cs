using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Datos;
using Entidades;

namespace Negocio
{
    public class UsuarioNegocio
    {
        ServicioCliente SC = new ServicioCliente();
        ServicioCuenta SCU = new ServicioCuenta();
        ServicioPrestamo SP = new ServicioPrestamo();
        ServicioTarjeta ST = new ServicioTarjeta();

        #region INSERT
        public void Insertar(Cliente cliente)
        {
            SC.Insertar(cliente);
        }

        public void Insertar(Cuenta cuenta)
        {
            SCU.Insertar(cuenta);
        }


        public void Insertar(Prestamo prestamo)
        {
            SP.Insertar(prestamo);
        }

        public void Insertar(TarjetaCredito tarjeta)
        {
            ST.Insertar(tarjeta);
        }

        public void Signup(Usuario usuario)
        {
            SC.Signup(usuario);
        }


        #endregion

        #region LIST
        public List<Cliente> Listar()
        {
            return SC.Listar();
        }

        public List<Cuenta> Listar2()
        {
            return SCU.Listar2();
        }

        public void GetDatos()
        {
            SCU.getDatos();
        }

        public List<Prestamo> Listar3()
        {
            return SP.Listar3();
        }

        public List<TarjetaCredito> Listar4()
        {
            return ST.Listar4();
        }
        #endregion

        #region EDIT
        public void Editar(Cliente cliente, int id)
        {

            SC.Editar(cliente, id);
        }

        //public void GetCliente(int id)
        //{
        //    SC.GetCliente(id);
        //}

        public void Editar2(Cuenta cuenta, int id)
        {

            SCU.Editar2(cuenta,id);

        }




        public void Editar3(Prestamo prestamo, int id)
        {

            SP.Editar3(prestamo, id);
        }

        public void Editar4(TarjetaCredito tarjeta, int id)
        {

            ST.Editar4(tarjeta, id);
        }

        #endregion

        #region DELETE
        public void Eliminar(int id)
        {
            SC.Eliminar(id);
        }
        public void Eliminar2(int id)
        {
            SCU.Eliminar2(id);
        }
        public void Eliminar3(int id)
        {
            SP.Eliminar3(id);
        }
        public void Eliminar4(int id)
        {
            ST.Eliminar4(id);
        }
        #endregion

        #region PROCEDURE
        public void SP_Deposito(Nullable<int> idC, Nullable<int> numC, Nullable<decimal> cantidad, Nullable<System.DateTime> fechaR, string accion)
        {

            SCU.SP_Deposito(idC,numC,cantidad,fechaR,accion);

        }
        public void SP_Retiro(Nullable<int> idC, Nullable<int> numC, Nullable<decimal> cantidad, Nullable<System.DateTime> fechaR, string accion)
        {

            SCU.SP_Retiro(idC, numC, cantidad, fechaR, accion);

        }

        public void SP_BucarRD(string accion, string numC, Nullable<System.DateTime> fECHA1, Nullable<System.DateTime> fECHA2)
        {
            SCU.SP_BucarRD(accion,numC,fECHA1,fECHA2);

        }

        #endregion


    }
}


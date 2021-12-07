using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Entidades;

namespace Datos
{
    public class ServicioCliente
    {
        PFinalEntities db = new PFinalEntities();

       
        public void Insertar(Cliente cliente)
        {
            db.Clientes.Add(cliente);
            db.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            return db.Clientes.ToList();
        }

        public void Editar(Cliente c, int id)
        {
            using (var db = new PFinalEntities())
            {
                var data = db.Clientes.Where(a => a.Id == id).SingleOrDefault();

                if (data != null)
                {
                    data.Nombre = c.Nombre;
                    data.Cedula = c.Cedula;
                    data.Email = c.Email;

                    db.SaveChanges();


                }

            }
        }

        public void Eliminar(int id)
        {
            using (PFinalEntities d = new PFinalEntities())
            {
                var user = d.Clientes.Find(id);
                d.Clientes.Remove(user);
                d.SaveChanges();

            }
        }
       

        public void Signup(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }

        //public List<Cliente> GetCliente(int id)
        //{
            
        //    using (var c = new PFinalEntities())
        //    {
        //        var data = c.Clientes.Where(a => a.Id == id).SingleOrDefault();
        //    }

   

    }
}


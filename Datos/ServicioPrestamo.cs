using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class ServicioPrestamo
    {
        PFinalEntities db = new  PFinalEntities();

        public void Insertar(Prestamo prestamo)
        {
            db.Prestamoes.Add(prestamo);
            db.SaveChanges();
        }

        public List<Prestamo> Listar3()
        {
            return db.Prestamoes.ToList();
        }

        public void Editar3(Prestamo c, int id)
        {
            using (var db = new PFinalEntities())
            {
                var data = db.Prestamoes.Where(a => a.Id == id).SingleOrDefault();

                if (data != null)
                {
                    data.Codigo = c.Codigo;
                    data.Cuota = c.Cuota;
                    data.Monto = c.Monto;
                    data.FechaCreacion = c.FechaCreacion;
                    data.IdCliente = c.IdCliente;
                    


                    db.SaveChanges();


                }

            }
        }


        public void Eliminar3(int id)
        {
            using (PFinalEntities d = new PFinalEntities())
            {
                var user = d.Prestamoes.Find(id);
                d.Prestamoes.Remove(user);
                d.SaveChanges();

            }
        }
    }
}

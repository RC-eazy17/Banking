using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class ServicioTarjeta
    {
        PFinalEntities db = new PFinalEntities();
        public void Insertar(TarjetaCredito tarjeta)
        {
            db.TarjetaCreditoes.Add(tarjeta);
            db.SaveChanges();
        }

        public List<TarjetaCredito> Listar4()
        {
            return db.TarjetaCreditoes.ToList();
        }

        public void Editar4(TarjetaCredito c, int id)
        {
            using (var db = new PFinalEntities())
            {
                var data = db.TarjetaCreditoes.Where(a => a.id == id).SingleOrDefault();

                if (data != null)
                {
                    data.NumTarjeta = c.NumTarjeta;
                    data.Balance = c.Balance;
                    data.FechaCreacion = c.FechaCreacion;
                    data.IdCliente = c.IdCliente;

                    db.SaveChanges();


                }

            }
        }


        public void Eliminar4(int id)
        {
            using (PFinalEntities d = new PFinalEntities())
            {
                var user = d.TarjetaCreditoes.Find(id);
                d.TarjetaCreditoes.Remove(user);
                d.SaveChanges();

            }
        }
    }
}

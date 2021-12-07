using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ClienteModel data { get; set; }
    }
}
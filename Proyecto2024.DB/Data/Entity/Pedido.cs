using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.DB.Data.Entity
{
    public class Pedido : EntityBase
    {
        public string FechaPedido { get; set; }
        public string Estado { get; set; }
        public string Total { get; set; }
        public string MetodoPago { get; set; }

        public List<Cliente> Clientes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.DB.Data.Entity
{
    public class DetallesdePedido : EntityBase
    {
        public string Cantidad {  get; set; }
        public string PrecioUnitario { get; set; }
        public string Subtotal { get; set; }
    }
}

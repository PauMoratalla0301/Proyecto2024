using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.DB.Data.Entity
{
    public class Pago : EntityBase
    {
        
        public string FechadePago { get; set; }

        public string Monto { get; set; }

        public string MetododePago { get; set; }

        public int IdPago { get; set; }
        public Pago Pagos { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.DB.Data.Entity
{
    public class AgregaralCarrito : EntityBase
    {
        
       
        
            
            public string Producto { get; set; }
            public int Cantidad { get; set; }
            public DateTime Fecha;
        }


       
        
    }


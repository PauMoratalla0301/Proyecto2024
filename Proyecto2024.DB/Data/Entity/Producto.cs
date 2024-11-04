using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.DB.Data.Entity
{
    public class Producto : EntityBase
    {
        
        public string Descripcion { get; set; }

        
        public int Precio { get; set; }

        
        public string Categoria { get; set; }


        public int idProducto { get; set; }
        public int NombreProducto { get; set; }

        public List<Producto> Productos { get; set; }
    }
}

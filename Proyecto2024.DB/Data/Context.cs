using Azure;
using Microsoft.EntityFrameworkCore;
using Proyecto2024.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.DB.Data
{
    public class Context : DbContext
    {
       
        
           public DbSet<Cliente> Clientes { get; set; }
           public DbSet<Pedido> Pedidos { get; set; }
           public DbSet<DetallesdePedido> DetalledePedidos { get; set; }
           public DbSet<Pago> Pagos { get; set; }
           public DbSet<Producto> Productos { get; set; }
           public DbSet<AgregaralCarrito> AgregaralCarritos { get; set; }

        public Context(DbContextOptions options) : base(options) { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                               .SelectMany(t => t.GetForeignKeys())
                                               .Where(fk => !fk.IsOwnership
                                                            && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }






            base.OnModelCreating(modelBuilder);
        }
    }
}


    


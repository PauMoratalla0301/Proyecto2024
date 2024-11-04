using Proyecto2024.DB.Data;
using Proyecto2024.DB.Data.Entity;

namespace Proyecto2024.Server.Repositorio
{
    public class AgregaralCarritoRepositorio : Repositorio<AgregaralCarrito>, IAgregaralCarritoRepositorio
    {
        public AgregaralCarritoRepositorio(Context context) : base(context)
        {
            
            
        }
    }
}

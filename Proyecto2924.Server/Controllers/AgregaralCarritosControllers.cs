using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2024.DB.Data;
using Proyecto2024.DB.Data.Entity;
using Proyecto2024.Server.Repositorio;
using Proyecto2024.Shared.DTO;


namespace Proyecto2024.Server.Controllers
{
    [ApiController]
    [Route("api/AgregaralCarritos")]
    public class AgregaralCarritosControllers : ControllerBase
    {
        private readonly IAgregaralCarritoRepositorio repositorio;
        private readonly IMapper mapper;

        public AgregaralCarritosControllers(IAgregaralCarritoRepositorio repositorio
                                           , IMapper mapper)
                                            
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet] //api/AgregaralCarritos
        public async Task<ActionResult<List<AgregaralCarrito>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/AgregaralCarrito
        public async Task<ActionResult<AgregaralCarrito>> Get(int id)
        {
            AgregaralCarrito? Paula = await repositorio.SelectById(id);
            if (Paula == null)
            {
                return NotFound();
            }
            return Paula;
        }

        
        [HttpGet("existe/{id:int}")] //api/AgregaralCarritos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(AgregaralCarritoDTO entidadDTO)
        {
            try
            {
               
                AgregaralCarrito entidad = mapper.Map<AgregaralCarrito>(entidadDTO);
                
                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }


        [HttpPut("{Id:int}")] //api/AgregaralCarritos
        public async Task<ActionResult> Put(int id, [FromBody] AgregaralCarrito entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var Paula = await repositorio.SelectById(id);
            if (Paula == null)
            {
                return NotFound("No existe el producto buscado");
            }

            Paula.Fecha = entidad.Fecha;
            Paula.Producto = entidad.Producto;
            Paula.Cantidad = entidad.Cantidad;
            
            try
            {
                await repositorio.Update(id,Paula);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id:int}")] //api/AgregaralCarritos
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"La oreden {id} no existe");
            }
            
           if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2024.DB.Data;
using Proyecto2024.DB.Data.Entity;
using Proyecto2024.Shared.DTO;

namespace Proyecto2024.Server.Repositorio
{
    public class Repositorio<E> :  IRepositorio<E>
                  where E : class, IEntityBase
    {
        private readonly Context context;

        public Repositorio(Context context)
        {
            this.context = context;
        }

        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>()
                .AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E> SelectById(int id)
        {
            E? Paula = await context.Set<E>()
                .AsNoTracking()
                .FirstOrDefaultAsync(
                x => x.Id == id);

            return Paula;
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {

                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }
            var Paula = await context.Set<E>()
                       .Where(reg => reg.Id == id)
                       .FirstOrDefaultAsync();

            if (Paula == null)
            {
                return false;
            }



            try
            {
                 context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> Delete(int id)
        {
            var Paula = await SelectById(id);
            if (Paula == null)
            {
                return false;
            }


            context.Set<E>().Remove(Paula);
            await context.SaveChangesAsync();
            return true;

        }
    }
}

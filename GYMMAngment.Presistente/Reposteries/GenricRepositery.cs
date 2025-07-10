using Gym.Mangment.Domain.Contract;
using GYMMAngment.Presistente.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMMAngment.Presistente.Reposteries
{
    public class GenricRepositery<TEntity, TKey>(ApplicationContext context) : IGenericRepo<TEntity, TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool WithTracking = false)
        {
            return WithTracking ? await context.Set<TEntity>().ToListAsync() :
                    await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
                
        public async Task AddAsync(TEntity entity)
                =>await context.Set<TEntity>().AddAsync(entity);
        
        public void UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
        public void DeleteAsync(TEntity entity)
                =>context.Set<TEntity>().Remove(entity);
    }
}

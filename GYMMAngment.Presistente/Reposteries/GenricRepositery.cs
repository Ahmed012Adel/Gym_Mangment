using Gym.Mangment.Domain.Contract;
using Gym.Mangment.Domain.Entities;
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
        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync
            (ISpecification<TEntity> specification, bool WithTracking = false)
        {
            return await ApplyQuery(specification).ToListAsync();
        }
       

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetWithSpecAsync(ISpecification<TEntity> specification)
        {
            return await ApplyQuery(specification).FirstOrDefaultAsync();
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


        private IQueryable<TEntity> ApplyQuery(ISpecification<TEntity> specification)
        {
            return SpecificstionEvaluter<TEntity>.GetQuery(context.Set<TEntity>(), specification);
        }

        
    }
}

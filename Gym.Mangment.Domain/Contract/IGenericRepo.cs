using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Mangment.Domain.Contract
{
    public interface IGenericRepo<TEntity,TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        public Task<TEntity?> GetByIdAsync(TKey id);
        public Task<IEnumerable<TEntity>> GetAllAsync(bool WithTracking = false);
        public Task AddAsync(TEntity entity);
        public void UpdateAsync(TEntity entity);
        public void DeleteAsync(TEntity entity);
    }
}

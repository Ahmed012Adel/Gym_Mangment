using Gym.Mangment.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Mangment.Domain.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; set; }
        public List<Expression<Func<TEntity, object>>>? Includes { get; set; } = new();
        public Expression<Func<TEntity, object>>? OrderBy { get; set; } = null;
        public Expression<Func<TEntity, object>>? OrderByDescending { get; set; } = null;

        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<TEntity , bool>>? expression)
        {
            Criteria = expression;
        }
       
        private protected virtual void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        private protected virtual void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        private protected virtual void AddInclude()
        {
        }

    }

}

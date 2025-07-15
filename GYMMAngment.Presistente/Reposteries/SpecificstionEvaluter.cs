using Gym.Mangment.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMMAngment.Presistente.Reposteries
{
    public class SpecificstionEvaluter<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> Inputquery , ISpecification<TEntity> specification)
        {
            var Query = Inputquery;

            if (specification.Criteria is not null)
                Query = Query.Where(specification.Criteria);
            if (specification.OrderBy is not null)
                Query = Query.OrderBy(specification.OrderBy);
            if (specification.OrderByDescending is not null)
                Query = Query.OrderByDescending(specification.OrderByDescending);

            return Query;
        }
        
    }
}

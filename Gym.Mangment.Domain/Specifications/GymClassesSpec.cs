using Gym.Mangment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Mangment.Domain.Specifications
{
    public class GymClassesSpec :BaseSpecification<GYMClasses>
    {
        public GymClassesSpec()
        {
            AddInclude();
        }
        private GymClassesSpec(Expression<Func<GYMClasses , bool>> expression):base(expression)
        {
            AddInclude();
        }

        public static GymClassesSpec GetById(int id)
        {
            return new GymClassesSpec(GYMClasses => GYMClasses.Id == id);
        }
        private protected override void AddInclude()
        {
            base.AddInclude();


            Includes.Add(GYMClasses => GYMClasses.Trainer);
            Includes.Add(GYMClasses => GYMClasses.Member);
        }
    }
}

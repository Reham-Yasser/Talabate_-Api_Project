using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Talabat.DAL.Entities;

namespace Talabat.API.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get ; set ; }
        public List<Expression<Func<T, object>>> Includes { get ; set ; }

        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
        }
        public BaseSpecification()
        {

        }

        public void AddInclude(Expression<Func<T, object>> Include)
        {
            Includes.Add(Include);
        }

    }
}

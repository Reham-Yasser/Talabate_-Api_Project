using Microsoft.EntityFrameworkCore;
using System.Linq;
using Talabat.DAL.Entities;

namespace Talabat.API.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if(spec.Criteria != null)
                query = query.Where(spec.Criteria);

            query = spec.Includes.Aggregate(query , (currentQuery , include) => currentQuery.Include(include));
            return query;
        }


    }
}

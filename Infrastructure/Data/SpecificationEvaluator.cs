using System.Linq;
using Core.EntitiesDb;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, 
        ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // p => p.ItmemTypeId == id
            }

            //taking the includes statements(types and brands) them and aggregate them into a query and then return results 

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query; 
        }
        
        
    }
}
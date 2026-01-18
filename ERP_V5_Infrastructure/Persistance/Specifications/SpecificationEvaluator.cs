using ERP_V5_Application.Common.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Infrastructure.Persistance.Specifications
{
    public static class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(
            IQueryable<T> inputQuery,
            ISpecification<T> specification
            )
        {
            var query = inputQuery;

            // filtering
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // 2 includes
            if (specification.Includes.Any())
            {
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            }

            // 3 Sorting 
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDesceding != null)
            {
                query = query.OrderByDescending(specification.OrderByDesceding);
            }

            // 4 pagination
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip!.Value).Take(specification.Take!.Value);
            }
            return query;
        }
    }
}

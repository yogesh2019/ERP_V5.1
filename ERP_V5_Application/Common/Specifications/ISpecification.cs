using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Common.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T, object>>? OrderBy { get; }
        Expression<Func<T, object>>? OrderByDesceding { get; }


        int? Skip { get; }
        int? Take { get; }
        bool IsPagingEnabled { get; }
    }
}

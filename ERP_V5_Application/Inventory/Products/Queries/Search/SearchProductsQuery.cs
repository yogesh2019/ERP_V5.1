using ERP_V5_Application.Common.Models;
using ERP_V5_Application.Inventory.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.Queries.Search
{
    public sealed record SearchProductsQuery(
        string? Name,
        Guid? CategoryId,
        int Page = 1,
        int PageSize = 20
        ) : IRequest<PagedResult<ProductDto>>;
}

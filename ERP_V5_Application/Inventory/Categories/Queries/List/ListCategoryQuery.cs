using ERP_V5_Application.Inventory.Categories.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Categories.Queries.List
{

    public sealed record ListCategoriesQuery()
        : IRequest<IReadOnlyList<CategoryDto>>;
}

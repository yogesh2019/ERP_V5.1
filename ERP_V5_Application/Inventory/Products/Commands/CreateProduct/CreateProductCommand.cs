using ERP_V5_Application.Common.Models;
using ERP_V5_Application.Inventory.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.Commands.CreateProduct
{
    public sealed record CreateProductCommand(
        string Name,
        int StockQty,
        decimal Price,
        Guid CategoryId
    ) : IRequest<Result<ProductDto>>;
}

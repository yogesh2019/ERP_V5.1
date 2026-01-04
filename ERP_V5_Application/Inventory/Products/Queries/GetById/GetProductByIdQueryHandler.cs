using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Application.Inventory.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.Queries.GetProductById
{
    public sealed class GetProductByIdQueryHandler(IProductRepository repo) : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await repo.GetByIdAsync(request.id, cancellationToken);
            return product is null ? null : product.ToDto();
        }
    }
}

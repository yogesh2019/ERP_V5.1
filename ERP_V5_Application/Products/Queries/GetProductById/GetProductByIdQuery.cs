using ERP_V5_Application.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Products.Queries.GetProductById
{
    public sealed record GetProductByIdQuery(Guid id) : IRequest<ProductDto>;
}

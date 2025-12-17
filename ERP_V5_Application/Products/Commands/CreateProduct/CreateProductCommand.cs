using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Products.Commands.CreateProduct;
public sealed record CreateProductCommand(
    string Name,
    int StockQty,
    decimal Price
    ) : IRequest<CreateProductResult>;
public sealed record CreateProductResult(Guid ProductId);

using ERP_V5_Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.Commands.UpdateProduct
{
    public sealed record UpdateProductCommand(
        Guid ProductId,
        string Name,
        decimal Price,
        bool isActive

        ) : IRequest<Result>;
}

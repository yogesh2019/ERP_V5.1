using ERP_V5_Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.Commands.DeleteProduct
{
    public sealed record DeleteProductCommand(Guid ProductId) :
        IRequest<Result>;
}

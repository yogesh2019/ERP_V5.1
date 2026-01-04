using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.DTOs
{
    public sealed class UpdateProductRequest
    {
        public string Name { get; init; } = null!;
        public decimal Price { get; init; }
        public bool IsActive { get; init; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Products.DTOs
{
    public sealed class CreateProductRequest
    {
        public string Name { get; init; } = null!;
        public int StockQty { get; init; }
        public decimal Price { get; init; }
        public Guid CategoryId { get; init; }
    }
}

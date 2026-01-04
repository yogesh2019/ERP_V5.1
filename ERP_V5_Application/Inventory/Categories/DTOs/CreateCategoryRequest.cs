using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Inventory.Categories.DTOs
{
    public sealed class CreateCategoryRequest
    {
        public string Name { get; init; } = null!;
    }
}

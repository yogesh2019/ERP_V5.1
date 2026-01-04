using ERP_V5_Domain.Inventory.Common;
using ERP_V5_Domain.Inventory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Domain.Inventory.Categories
{
    public class Category : BaseEntity
    {
        private readonly List<Product> _products = new();
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
        public bool IsActive { get; private set; }
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
        private Category()
        {

        }
        public Category(string name, string description)
        {
            Id = Guid.NewGuid();
            SetName(name);

        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Category name is required");
            }
            Name = name.Trim();
            MarkUpdated();
        }
        public void Deactivate()
        {
            IsActive = false;
            MarkUpdated();
        }

    }
}

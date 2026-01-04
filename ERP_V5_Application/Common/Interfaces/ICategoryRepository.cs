using ERP_V5_Domain.Inventory.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Application.Common.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<bool> ExistsByNameAsyc(string name, CancellationToken ct = default);
        Task AddAsync(Category category, CancellationToken ct = default);
    }
}

using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Domain.Inventory.Categories;
using ERP_V5_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Infrastructure.Persistance.Repositories
{

    public sealed class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Category?> GetByIdAsync(
            Guid id,
            CancellationToken ct = default)
        {
            return await _db.Categories
                .FirstOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<bool> ExistsByNameAsyc(
            string name,
            CancellationToken ct = default)
        {
            return await _db.Categories
                .AnyAsync(c => c.Name == name && c.DeletedAt == null, ct);
        }

        public async Task AddAsync(
            Category category,
            CancellationToken ct = default)
        {
            await _db.Categories.AddAsync(category, ct);
        }
    }
}

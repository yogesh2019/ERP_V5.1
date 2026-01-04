using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Domain.Inventory.Common;
using ERP_V5_Domain.Inventory.Products;
using ERP_V5_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ERP_V5_Infrastructure.Persistance.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;
    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }
    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _db.AddAsync(product, cancellationToken);
    }

    public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return _db.Products.AsNoTracking().AnyAsync(p => p.Name == name, cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _db.Products.AsNoTracking().ToListAsync(cancellationToken);
    }

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Remove(Product product)
    {
        _db.Products.Update(product);
    }


    public void Update(Product product)
    {
        _db.Products.Remove(product);
    }

    public async Task<IReadOnlyList<Product>> SearchAsync(
        string? name,
        Guid? categoryId,
        int page,
        int pageSize,
        CancellationToken ct = default)
    {
        IQueryable<Product> query = _db.Products.AsNoTracking();

        // Soft delete filter (if not using global query filters)
        query = query.Where(p => p.DeletedAt == null);

        // Filter by name
        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(p =>
                EF.Functions.Contains(p.Name, $"%{name.Trim()}%"));
            // Use .Contains for SQL Server if needed
        }

        // Filter by category
        if (categoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == categoryId.Value);
        }

        // Ordering (stable pagination)
        query = query.OrderBy(p => p.Name);

        // Pagination
        query = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return await query.ToListAsync(ct);
    }
}

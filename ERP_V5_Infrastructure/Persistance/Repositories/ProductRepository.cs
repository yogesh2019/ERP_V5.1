using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Domain.Products;
using ERP_V5_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

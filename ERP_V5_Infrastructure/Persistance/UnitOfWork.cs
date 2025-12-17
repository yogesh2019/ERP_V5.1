using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Infrastructure.Persistance.Repositories;
using ERP_V5_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Infrastructure.Persistance;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;
    private IProductRepository _productRepository;
    private IDbContextTransaction _dbContextTransaction;
    public UnitOfWork(AppDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public IProductRepository products => _productRepository ??= new ProductRepository(_db);

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_dbContextTransaction != null) return;
        _dbContextTransaction = await _db.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _db.SaveChangesAsync(cancellationToken);

            if (_dbContextTransaction != null)
            {
                await _dbContextTransaction.CommitAsync(cancellationToken);
            }
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            if (_dbContextTransaction != null)
            {
                await _dbContextTransaction.DisposeAsync();
                _dbContextTransaction = null;
            }
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_dbContextTransaction != null)
        {
            await _dbContextTransaction.DisposeAsync();
            _dbContextTransaction = null;
        }
        await _db.DisposeAsync();
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (_dbContextTransaction != null)
            {
                await _dbContextTransaction.RollbackAsync(cancellationToken);
            }

        }
        finally
        {
            if (_dbContextTransaction != null)
            {
                await _dbContextTransaction.DisposeAsync();
                _dbContextTransaction = null;
            }
        }

    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _db.SaveChangesAsync(cancellationToken);
    }
}

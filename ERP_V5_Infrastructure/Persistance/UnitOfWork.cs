using ERP_V5_Application.Common.Interfaces;
using ERP_V5_Domain.Common;
using ERP_V5_Infrastructure.Persistance.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
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
    private IDbContextTransaction _dbContextTransaction;
    private readonly IMediator _mediator;
    public UnitOfWork(AppDbContext db, IMediator mediator)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));

    }


    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_dbContextTransaction != null) return;
        _dbContextTransaction = await _db.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await DispatchDomainEventsAsync(cancellationToken);
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
    private async Task DispatchDomainEventsAsync(CancellationToken token)
    {
        var domainEvents = _db.ChangeTracker
            .Entries<AggregateRoot>().
            SelectMany(e => e.Entity.DomainEvent).ToList();

        foreach (var e in domainEvents)
        {
            await _mediator.Publish(e, token);
        }

        foreach (var entry in _db.ChangeTracker.Entries<AggregateRoot>())
        {
            entry.Entity.ClearDomainEvents();
        }
    }
}

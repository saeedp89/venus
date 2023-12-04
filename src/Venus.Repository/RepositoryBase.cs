using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Venus.Domain.Abstractions;
using Venus.Domain.Entities;

namespace Venus.Repository;

public class RepositoryBase<TEntity>(VenusDbContext context) : IRepositoryBase<TEntity>
    where TEntity :  VenusBaseEntity
{
    public async Task AddEntityAsync(TEntity entity, CancellationToken ct)
    {
        await context.AddAsync(entity, ct);
    }

    public void AddEntity(TEntity entity)
    {
        context.Add(entity);
    }

    public async Task DeleteEntityAsync(long id, CancellationToken ct)
    {
        var entity = await GetEntityAsync(id, ct);
        context.Remove(entity);
    }

    public void DeleteEntity(long id)
    {
        var entity = GetEntity(id);
        context.Remove(entity);
    }

    public Task UpdateEntityAsync(TEntity entity, CancellationToken ct)
    {
        context.Update(entity);
        return Task.CompletedTask;
    }

    public void UpdateEntity(TEntity entity)
    {
        context.Update(entity);
    }

    public async Task<TEntity> GetEntityAsync(long id, CancellationToken ct)
    {
        return await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);
    }

    public TEntity GetEntity(long id)
    {
        return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
    }

    public bool SaveChanges()
    {
        return context.SaveChanges() > 0;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
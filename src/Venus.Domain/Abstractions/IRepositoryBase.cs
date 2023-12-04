using Venus.Domain.Entities;

namespace Venus.Domain.Abstractions;

public interface IRepositoryBase<TEntity> where TEntity : VenusBaseEntity
{
    Task AddEntityAsync(TEntity entity, CancellationToken ct);
    void AddEntity(TEntity entity);

    Task DeleteEntityAsync(long id, CancellationToken ct);
    void DeleteEntity(long id);

    Task UpdateEntityAsync(TEntity entity, CancellationToken ct);
    void UpdateEntity(TEntity entity);

    Task<TEntity> GetEntityAsync(long id, CancellationToken ct);
    TEntity GetEntity(long id);

    bool SaveChanges();
    Task<bool> SaveChangesAsync();
}
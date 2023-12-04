namespace Venus.Domain.Entities;

public abstract record VenusBaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedOn { get; set; }
}

public interface IMutable
{
    public DateTime? UpdatedOn { get; set; }
}

public interface ISoftDelete
{
    public DateTime? DeletedOn { get; set; }
    public bool IsDeleted => !DeletedOn.HasValue;
}
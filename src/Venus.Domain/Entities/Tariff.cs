namespace Venus.Domain.Entities;

public record Tariff : VenusBaseEntity
{
    public TimeOnly From { get; set; }
    public TimeOnly To { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
}

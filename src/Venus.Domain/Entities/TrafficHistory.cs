namespace Venus.Domain.Entities;

public record TrafficHistory : VenusBaseEntity
{
    public string PlateNumber { get; set; }
    public DateTime RecordedOn { get; set; }
}
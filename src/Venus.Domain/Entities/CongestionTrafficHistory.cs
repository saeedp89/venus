namespace Venus.Domain.Entities;

public record CongestionTrafficHistory : VenusBaseEntity
{
    public long Vehicle { get; set; }
    public DateTime RecordedOn { get; set; }

}
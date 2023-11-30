namespace Venus.Domain;

public record CongestionHistory(Identity Id) : VenusBaseEntity(Id)
{
    public Guid CarNo { get; set; }
    public string CarCategory { get; set; } = "";
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
}

namespace Venus.Domain.Entities;

public record CongestionRule : VenusBaseEntity
{
    public decimal MaximumAmountPerDayPerVehicle { get; set; }
    public TimeSpan MinimumSpanForMaximumFee { get; set; }
    public bool IsActive { get; set; }
}
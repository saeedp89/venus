namespace Venus.Domain.Entities;

public record VehicleType : VenusBaseEntity
{
    public string Name { get; set; } = "";
    public bool FreeOfCharge { get; set; }
    public bool IsActive { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; }
}
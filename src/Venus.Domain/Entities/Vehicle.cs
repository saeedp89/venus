using System.ComponentModel.DataAnnotations.Schema;

namespace Venus.Domain.Entities;

public record Vehicle : VenusBaseEntity
{
    public string PlateNumber { get; set; } = "";


    public VehicleType VehicleType { get; set; }
    public long VehicleTypeId { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Venus.MVC.Models;

public class FreeOfChargeVehicleTypeViewModel
{
    public Guid Id { get; set; }
    public string VehicleType { get; set; }
}

public class FreeOfChargeVehicleTypeAddModel
{
    [Required]
    public string VehicleType { get; set; }
}

public class FreeOfChargeVehicleTypeEditModel
{
    public Guid Id { get; set; }
    public string VehicleType { get; set; }
}
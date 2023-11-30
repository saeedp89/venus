namespace Venus.Application;

public class Car : IVehicle
{
    public string Name { get; set; } = "";

    public String GetVehicleType()
    {
        return "Car";
    }
}
namespace Venus.MVC.Models;

public class CongestionRegionRecordViewModel
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public VehicleViewModel Vehicle { get; set; }
    public List<DateTime> RecordDate { get; set; }
}

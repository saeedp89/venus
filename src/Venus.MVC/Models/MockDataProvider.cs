using Venus.MVC.Models;

public class MockDataProvider
{
    public  readonly Dictionary<Guid, VehicleViewModel> VehicleRepository = new();

    private static MockDataProvider? _instance;

    public static MockDataProvider Instance => _instance ??= new MockDataProvider();

    private MockDataProvider()
    {
        foreach (var vsd in Vehicles())
        {
            VehicleRepository.Add(vsd.Id, vsd);
        }
    }

    private int Generate(int from, int to)
    {
        return new Random(DateTime.Now.TimeOfDay.Microseconds).Next(from, to);
    }

    public CongestionRegionRecordViewModel Get(Guid vehicleId, int count = 50)
    {
        var id = Guid.NewGuid();
        var dateTime = new List<DateTime>();
        for (int i = 0; i < 50; i++)
        {
            var d = new DateOnly(2013,
                Generate(1, 12), Generate(1, 29));
            var t = new TimeOnly(Generate(0, 23), Generate(0, 59), Generate(0, 59));

            dateTime.Add(new DateTime(d, t));
        }

        var types = new string[]
        {
            "Emergency vehicle", "Buses", "Diplomat vehicles", "Motorcycles", "Military vehicles", "Foreign vehicles"
        };

        var vehicleCongestionViewModels = new CongestionRegionRecordViewModel()
        {
            Id = id,
            VehicleId = vehicleId,
            RecordDate = dateTime,
            Vehicle = VehicleRepository[vehicleId]
        };
        return vehicleCongestionViewModels;
    }

    private List<VehicleViewModel> Vehicles(int count = 50)
    {
        var types = new string[]
        {
            "Emergency vehicle", "Buses", "Diplomat vehicles", "Motorcycles", "Military vehicles", "Foreign vehicles"
        };
        return Enumerable.Range(1, count).Select(x => new VehicleViewModel()
        {
            Id = Guid.NewGuid(),
            PlateNumber = Guid.NewGuid().ToString().Substring(1, 5),
            VehicleType = types[new Random(DateTime.Now.TimeOfDay.Microseconds).Next(0, 6)]
        }).ToList();
    }
}
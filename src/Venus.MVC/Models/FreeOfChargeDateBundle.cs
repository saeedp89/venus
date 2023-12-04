using System.Diagnostics;

namespace Venus.MVC.Models;

public class FreeOfChargeDateBundle
{
    public IEnumerable<DayOfWeek> DaysOfWeek { get; set; } = Array.Empty<DayOfWeek>();
    public bool PublicHolidays { get; set; }
    public IEnumerable<int> BeforeOrAfterHolidays { get; set; } = Array.Empty<int>();
}
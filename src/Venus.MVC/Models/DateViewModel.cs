namespace Venus.MVC.Models;

public struct DateViewModel
{
    public IEnumerable<DayOfWeek> DaysOfWeek { get; set; }
    public bool PublicHolidays { get; set; }
    public IEnumerable<int> BeforeOrAfterHoliday { get; set; }
}
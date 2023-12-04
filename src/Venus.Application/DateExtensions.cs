namespace Venus.Application;

public static class DateExtensions
{
    public static bool IsWeekend(this DateTime date) =>
        date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
}
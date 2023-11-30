using Microsoft.VisualBasic;

namespace Venus.Application;

public class CongestionTaxCalculator
{
    const int MaximumTaxAmountPerDayPerVehicle = 60;

    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */
    public int GetTax(IVehicle vehicle, DateTime[] dates)
    {
        var totalFee = 0;
        for (var count = 0; count < dates.Length; count++)
        {
            var startingTime = dates[count];
            var nextTime = GetNextDate(dates, count);

            if (nextTime.HasValue && WithinOneHour(startingTime, nextTime.Value))
            {
                return MaximumTaxAmountPerDayPerVehicle;
            }


            totalFee += GetTollFee(startingTime, vehicle);

            // var tempFee = GetTollFee(intervalStart, vehicle);

            // long diffInMillisecond = date.Millisecond - intervalStart.Millisecond;
            // var minutes = diffInMillisecond / 1000 / 60;

            // if (minutes <= 60)
            // {
            // if (totalFee > 0) totalFee -= tempFee;
            // if (nextFee >= tempFee) tempFee = nextFee;
            // totalFee += tempFee;
            // }
            // else
            // {
            // totalFee += nextFee;
            // }
        }

        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }

    private DateTime? GetNextDate(DateTime[] dates, int currentItemIndex)
    {
        const int nextDateIndex = 1;
        if (ExceedsArrayBoundaries())
            return null;
        return dates[currentItemIndex + nextDateIndex];

        bool ExceedsArrayBoundaries()
        {
            return currentItemIndex + nextDateIndex >= dates.Length;
        }
    }

    private bool WithinOneHour(DateTime from, DateTime to)
    {
        if (NotTheSameDay(from, to))
            return false;

        if (DifferGreaterThanOneHour(from, to))
        {
            return false;
        }

        return true;
    }

    private static bool DifferGreaterThanOneHour(DateTime from, DateTime to)
    {
        const double minutesInOneHour = 60.0;
        return Math.Abs(from.TimeOfDay.TotalMinutes - to.TimeOfDay.TotalMinutes) > minutesInOneHour;
    }

    private static bool NotTheSameDay(DateTime from, DateTime to)
    {
        return from.Date != to.Date;
    }


    private bool IsTollFreeVehicle(IVehicle? vehicle)
    {
        if (vehicle == null) return false;

        var vehicleType = vehicle.GetVehicleType();

        return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Military.ToString());
    }

    public int GetTollFee(DateTime date, IVehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

        var hour = date.Hour;
        var minute = date.Minute;

        if (hour == 6 && minute is >= 0 and <= 29) return 8;
        else if (hour == 6 && minute is >= 30 and <= 59) return 13;
        else if (hour == 7 && minute is >= 0 and <= 59) return 18;
        else if (hour == 8 && minute is >= 0 and <= 29) return 13;
        else if (hour == 8 && minute is >= 30 and <= 59 ||
                 hour is > 8 and <= 14 && minute is >= 0 and <= 59) return 8;
        else if (hour == 15 && minute is >= 0 and <= 29) return 13;
        else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
        else if (hour == 17 && minute is >= 0 and <= 59) return 13;
        else if (hour == 18 && minute is >= 0 and <= 29) return 8;
        else return 0;
    }

    private static bool IsTollFreeDate(DateTime date)
    {
        var year = date.Year;
        var month = date.Month;
        var day = date.Day;

        if (date.IsWeekend()) return true;

        if (year == 2013)
        {
            // if (date.IsPublicHoliday() || date.IsWeekend() || date.IsInJuly())
            // {
            // return true;
            // }

            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return true;
            }
        }

        return false;
    }

    private enum TollFreeVehicles
    {
        Motorcycle = 0,
        Tractor = 1,
        Emergency = 2,
        Diplomat = 3,
        Foreign = 4,
        Military = 5
    }
}

public static class DateExtensions
{
    public static bool IsWeekend(this DateTime date) =>
        date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
}
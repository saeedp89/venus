using Venus.Domain.Abstractions;
using Venus.Domain.Entities;

namespace Venus.Application;

public class CongestionFeeCalculator : ICongestionFeeCalculator
{
    const int MaximumFeePerDayPerVehicle = 60;

    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param records   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */
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

    //
    // private bool IsTollFreeVehicle(? vehicle)
    // {
    //     if (vehicle == null) return false;
    //
    //     var vehicleType = vehicle.GetVehicleType();
    //
    //     return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
    //            vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
    //            vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
    //            vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
    //            vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
    //            vehicleType.Equals(TollFreeVehicles.Military.ToString());
    // }
    //
    public int GetTollFee(DateTime date, Vehicle vehicle)
    {
        // if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

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
        var publicHolidays = new List<Tuple<int, int[]>>();
        publicHolidays.Add(new(1, new[] { 1 }));
        publicHolidays.Add(new(3, new[] { 28, 29 }));
        publicHolidays.Add(new(4, new[] { 28, 29 }));

        if (year == 2013)
        {
            if (month == 1 && day is 1 ||
                month == 3 && day is 28 or 29 ||
                month == 4 && day is 1 or 30 ||
                month == 5 && day is 1 or 8 or 9 ||
                month == 6 && day is 5 or 6 or 21 ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && day is 24 or 25 or 26 or 31)
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

    public decimal Calculate(DateTime[] records, Vehicle vehicle)
    {
        var totalFee = 0;

        if (VehicleTypeIsFreeOfCharge(vehicle))
            return 0;
        if (DateTypeIsFreeOfCharge(records.First().Date))

            for (var count = 0; count < records.Length; count++)
            {
                var startingTime = records[count];
                var nextTime = GetNextDate(records, count);

                if (nextTime.HasValue && WithinOneHour(startingTime, nextTime.Value))
                {
                    return MaximumFeePerDayPerVehicle;
                }


                totalFee += GetTollFee(startingTime, vehicle);

                var tempFee = GetTollFee(startingTime, vehicle);

            }

        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }

    private bool VehicleTypeIsFreeOfCharge(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }

    private bool DateTypeIsFreeOfCharge(DateTime date)
    {
        throw new NotImplementedException();
    }

}
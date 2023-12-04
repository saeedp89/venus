// See https://aka.ms/new-console-template for more information

using Venus.Application;

var dates = """
            2013-01-14 21:00:00
            2013-01-15 21:00:00
            2013-02-07 06:23:27
            2013-02-07 15:27:00
            2013-02-08 06:27:00
            2013-02-08 06:20:27
            2013-02-08 14:35:00
            2013-02-08 15:29:00
            2013-02-08 15:47:00
            2013-02-08 16:01:00
            2013-02-08 16:48:00
            2013-02-08 17:49:00
            2013-02-08 18:29:00
            2013-02-08 18:35:00
            2013-03-26 14:25:00
            2013-03-28 14:07:27
            """;
var listOfDates = dates.Split("\r\n").Select(DateTime.Parse).ToList();
var eachDayList = listOfDates.GroupBy(x => x.Date).ToList();
var calc = new CongestionFeeCalculator();
foreach (var d in eachDayList)
{
    foreach (var dd in d)
    {
        Console.Write($"{dd,-30}");
    }

    // Console.WriteLine($"\nDate: {d.Key}\nTax: {calc.GetTax(new Car(), d.ToArray())}");

    Console.WriteLine($"###################################");
}
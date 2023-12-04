namespace Venus.Application;

public struct TimeIntervalBasedFeeViewModel
{
    public TimeOnly From { get; set; }
    public TimeOnly To { get; set; }
    public decimal Price { get; set; }
}
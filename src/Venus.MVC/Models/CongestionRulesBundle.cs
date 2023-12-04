using Venus.Application;

namespace Venus.MVC.Models;

public class CongestionRulesBundle
{
    // VehicleTypes that are exempt
    public IEnumerable<VehicleTypeViewModel> FreeOfChargeVehiclesViewModels { get; set; } =
        Array.Empty<VehicleTypeViewModel>();

    // special dates that are exempt
    public IEnumerable<DateViewModel> FreeOfChargeDateViewModels { get; set; } = Array.Empty<DateViewModel>();

    // Intervals and their price
    public IEnumerable<TimeIntervalBasedFeeViewModel> Fees { get; set; }

    // maximum price per day per vehicle
    public decimal MaximumPricePerDayPerVehicle { get; set; }

    // SinglePayment Rule Interval
    public float SinglePaymentRuleInterval { get; set; }
}
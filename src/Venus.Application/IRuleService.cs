namespace Venus.Application;

public interface IRuleService
{
    IEnumerable<TimeIntervalBasedFeeViewModel> GetTariffs();
}
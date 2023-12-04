using Venus.Domain.Entities;

namespace Venus.Domain.Abstractions;

public interface ICongestionFeeCalculator
{
    decimal Calculate(DateTime[] records,Vehicle vehicle);
}
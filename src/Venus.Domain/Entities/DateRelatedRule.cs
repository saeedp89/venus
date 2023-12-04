namespace Venus.Domain.Entities;

public record DateRelatedRule : VenusBaseEntity
{
    public IEnumerable<DayOfWeek> Days { get; set; }
    public IEnumerable<Month> Months { get; set; }
    public bool PublicHolidays { get; set; }
    public int DaysBeforePublicHolidays { get; set; }
    public int DaysAfterPublicHolidays { get; set; }
    public bool IsFreeOfCharge { get; set; }

    public bool IsActive { get; set; }
}
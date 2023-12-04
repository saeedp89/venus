namespace Venus.MVC.Models;

public class CongestionRuleViewModel
{
    public Guid Id { get; set; }
    public TimeOnly From { get; set; }
    public TimeOnly To { get; set; }
    public decimal Price { get; set; }
}
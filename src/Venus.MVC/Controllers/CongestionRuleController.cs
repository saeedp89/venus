using Microsoft.AspNetCore.Mvc;
using Venus.Application;
using Venus.MVC.Models;

namespace Venus.MVC.Controllers;

public class CongestionRuleController : Controller
{
    private readonly IRuleService _timeBaseFeeService;

    public CongestionRuleController(IRuleService timeBaseFeeService)
    {
        _timeBaseFeeService = timeBaseFeeService;
    }

    public IActionResult Index()
    {
        var data = new CongestionRulesBundle();
        data.Fees = _timeBaseFeeService.GetTariffs();
        return View(new CongestionRulesBundle());
    }


}


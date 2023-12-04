using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Venus.MVC.Models;

namespace Venus.MVC.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(MockDataProvider.Instance.VehicleRepository.Values);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult History(Guid id)
        {
            return View(MockDataProvider.Instance.Get(id));
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
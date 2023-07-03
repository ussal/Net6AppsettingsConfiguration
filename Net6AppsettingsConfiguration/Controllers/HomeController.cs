using Microsoft.AspNetCore.Mvc;
using Net6AppsettingsConfiguration.Helpers;
using Net6AppsettingsConfiguration.Models;
using System.Diagnostics;

namespace Net6AppsettingsConfiguration.Controllers
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
            //Getting configuration string
            var configText = ConfigurationHelper.GetConfigurationString("Application:configText");
            //Send data to View
            ViewData["configText"] = configText;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using yuta_SampleWeb01.Models;

namespace yuta_SampleWeb01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            _logger.LogTrace("Trace で出力します。");
            _logger.LogDebug("Debug で出力します。");
            _logger.LogInformation("Information で出力します。");
            _logger.LogWarning("Warning で出力します。");
            _logger.LogError("Error で出力します。");
            _logger.LogCritical("Critical で出力します。");

        }

        public IActionResult Index()
        {
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
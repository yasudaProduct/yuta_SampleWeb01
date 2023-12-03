using Merino.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using yuta_SampleWeb01.Models;

namespace yuta_SampleWeb01.Controllers
{
    [TypeFilter(typeof(AccessLogFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string userId = User.FindFirst(ClaimTypes.Name).Value;
            string role = User.FindFirst(ClaimTypes.Role).Value;
            ViewData["UserID"] = userId;
            ViewData["Role"] = role;
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
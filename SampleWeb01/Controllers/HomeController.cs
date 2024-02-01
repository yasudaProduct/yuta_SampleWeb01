using Merino.config;
using Merino.Controller;
using Merino.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Security.Claims;
using SampleWeb01.ViewModels;

namespace SampleWeb01.Controllers
{

    public class HomeController : MerinoController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppSetteings _setting;

        public HomeController(ILogger<HomeController> logger, IOptionsSnapshot<AppSetteings> optons)
        {
            _logger = logger;
            _setting = optons.Value;
        }

        public IActionResult Index()
        {

            string userId = User.FindFirst(nameof(AppCookieDto.Id)).Value;
            string name = User.FindFirst(nameof(AppCookieDto.Name)).Value;
            ViewData["UserID"] = userId;
            ViewData["Name"] = name;
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
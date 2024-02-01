using Microsoft.AspNetCore.Mvc;

namespace SampleWeb01.Controllers
{
    public class DataAAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

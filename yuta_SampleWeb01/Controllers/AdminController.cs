using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace yuta_SampleWeb01.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        
    }
}

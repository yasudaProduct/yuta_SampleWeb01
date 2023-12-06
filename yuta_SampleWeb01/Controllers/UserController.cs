using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using yuta_SampleWeb01.ViewModels;
using yuta_SampleWeb01.Services;
using Merino.Filters;
using Merino.Controller;

namespace yuta_SampleWeb01.Controllers
{

    [TypeFilter(typeof(AccessLogFilter))]
    public class UserController : MerinoController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View(new UserViewModel());
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel user)
        {
            try
            {
                _service.create(user);
            }
            catch
            {
                
            }

            return View();
        }

    }
}

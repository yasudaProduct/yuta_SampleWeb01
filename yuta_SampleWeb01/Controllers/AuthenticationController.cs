using Merino.Controller;
using Merino.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace yuta_SampleWeb01.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : MerinoController
    {

        private readonly ILogger _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string loginId, string password)
        {

            if (string.IsNullOrWhiteSpace(loginId) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(string.Empty, "ログイン情報に誤りがあります。");
                return View("Index");
            }

            string role = loginId == "admin" ? "Administrator" : "General";

            base.AddCookie<AppCookieDto>(new AppCookieDto() 
                { 
                Id = loginId,
                Name = "めりの", // TODO 
                });

            _logger.LogInformation($"Controller:{nameof(AuthenticationController)} Action:{nameof(AuthenticationController.Login)} User:{loginId} Success!");

            // 認証されたらHomeページへリダイレクトする
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            // 認証Cookieをレスポンスから削除
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!(userId is null))
            {
                _logger.LogInformation($"Controller:{nameof(AuthenticationController)} Action:{nameof(AuthenticationController.Logout)} User:{userId} Success!");
            }

            // ログイン画面にリダイレクト
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }

    public class AppCookieDto : CookieDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}

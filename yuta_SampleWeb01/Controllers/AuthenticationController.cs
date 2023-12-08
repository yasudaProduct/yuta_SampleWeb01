using Merino.Controller;
using Merino.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using yuta_SampleWeb01.Models;
using yuta_SampleWeb01.Services;

namespace yuta_SampleWeb01.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : MerinoController
    {

        private readonly ILogger _logger;

        private readonly IAuthService _service;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthService service)
        {
            _logger = logger;
            _service = service;
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

            //認証処理
            TUser user = _service.Auth(loginId, password);
            if(user == null)
            {
                ModelState.AddModelError(string.Empty, "ログイン情報に誤りがあります。");
                return View();
            }

            //ユーザー情報取得 (Authに入れてもいいかも)
            //TODO Userテーブルが分かれていた場合どっちのテーブルから取得するの？ 区分を設けなきゃ？

            string role = loginId == "admin" ? "Administrator" : "General";

            //認証Cookie作成
            base.AddCookie<AppCookieDto>(new AppCookieDto() 
                { 
                Id = loginId,
                Name = "めりの", // TODO
                });

            _logger.LogInformation($"Controller:{nameof(AuthenticationController)} Action:{nameof(AuthenticationController.Login)} User:{loginId} Success!");

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

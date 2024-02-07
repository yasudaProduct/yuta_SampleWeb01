using Merino.Controller;
using Merino.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleWeb01.Application.Interface;
using SampleWeb01.Application.UseCase;
using SampleWeb01.Application.UseCase.Auth.Dto;
using SampleWeb01.ViewModels;
using System.Security.Claims;

namespace SampleWeb01.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : MerinoController
    {

        private readonly ILogger _logger;

        private readonly IAuthService _authService;

        private readonly IUserQueryService _userQueryService;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IAuthService authService,
            IUserQueryService userQueryservice)
        {
            _logger = logger;
            _userQueryService = userQueryservice;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            //入力チェック
            if (!ModelState.IsValid) return View(model);

            //認証処理
            AuthRequest req = new AuthRequest(model.LoginId, model.Password);
            AuthResponse res = _authService.Auth(req);
            if (res == null)
            {
                ModelState.AddModelError(string.Empty, "ログイン情報に誤りがあります。");
                return View();
            }

            //ユーザー情報取得 (Authに入れてもいいかも)
            //TODO Userテーブルが分かれていた場合どっちのテーブルから取得するの？ 区分を設けなきゃ？

            string role = model.LoginId == "admin" ? "Administrator" : "General";

            //認証Cookie作成
            base.AddCookie<AppCookieDto>(new AppCookieDto() 
                { 
                Id = model.LoginId,
                Name = "めりの", // TODO
                });

            _logger.LogInformation($"Controller:{nameof(AuthenticationController)} Action:{nameof(AuthenticationController.Login)} User:{model.LoginId} Success!");

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
